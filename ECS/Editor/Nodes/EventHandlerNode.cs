using System.CodeDom;

namespace Invert.ECS.Graphs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;

   
    public class EventHandlerNode : EventHandlerNodeBase, ICodeOutput
    {
        public HandlersReference EventHandler
        {
            get { return this.InputFrom<HandlersReference>(); }
        }

        [ReferenceSection("Required Components", SectionVisibility.WhenNodeIsNotFilter, 
            true, false, typeof(IRequiredComponentsConnectable), true, 
            OrderIndex = 0, HasPredefinedOptions = false,
            AddCommandType = typeof(VariableSelectionCommand<RequiredComponentsReference>))]
        public override System.Collections.Generic.IEnumerable<RequiredComponentsReference> RequiredComponents
        {
            get
            {
                return ChildItems.OfType<RequiredComponentsReference>();
            }
        }

        public EventsChildItem EventType
        {
            get
            {
                if (EventHandler == null) return null;
                return EventHandler.SourceItem as EventsChildItem;
            }
        }

        public EventNode EventTypeNode
        {
            get
            {
                if (EventType == null)
                    return null;
                return EventType.RelatedTypeNode as EventNode;
            }
        }

        public override IEnumerable<IRequiredComponentsConnectable> PossibleRequiredComponents
        {
            get
            {
                return AllContextVariables.OfType<IRequiredComponent>().Where(p => p.IsEntity).Cast<IRequiredComponentsConnectable>();
               
                //if (EventTypeNode == null) yield break;
                //foreach (var item in EventTypeNode.Properties.Where(p => p.IsEntity).Cast<IEventHandlerEntityMapping>())
                //    yield return item;
                //foreach (var item in EventTypeNode.Collections.Where(p => p.IsEntity).Cast<IEventHandlerEntityMapping>())
                //    yield return item;

            }
        }

        public override void Validate(List<ErrorInfo> errors)
        {
            base.Validate(errors);
            if (EventHandler == null)
            {
                // errors.AddError("A System Event Handler must be connected to this EventHandler Node.");
            }
            if (EventType == null)
            {
                //  errors.AddError("Event Type could not be found.");
            }
            //if (EventTypeNode==null)
            //{
            //    errors.AddError("The event type must be associated with an event class");
            //}
            if (Outputs.Any())
            {
                var contextVariables = AllContextVariables.ToArray();
                foreach (var output in RequiredComponents)
                {
                    if (contextVariables.All(p => p.VariableName != output.Name))
                    {
                        errors.AddError(string.Format("Variable {0} was not found.", output.Name),this.Node.Identifier);
                    }
                }
            }

        }

        public override IEnumerable<IContextVariable> ContextVariables
        {
            get
            {
                foreach (var item in this.RequiredComponents)
                {
                    var component = item.Component;
                    if (component != null)
                    {
                        foreach (var c in component.Properties)
                            yield return new ContextVariable(component.ClassName.ToLower(), c)
                            {
                                SourceVariable = c
                            };
                        foreach (var c in component.Collections)
                            yield return new ContextVariable(component.ClassName.ToLower(), c)
                            {
                                SourceVariable = c
                            };
                    }
                }
                
                if (EventTypeNode == null) yield break;
                foreach (var item in EventTypeNode.Properties)
                {
                    yield return new ContextVariable("eventData",item)
                    {
                        SourceVariable = item
                    };
                }
                foreach (var item in EventTypeNode.Collections)
                {
                    yield return new ContextVariable("eventData", item)
                    {
                        SourceVariable = item
                    };
                }
             
            }
        }

        public override void WriteCode(TemplateContext ctx)
        {
          
   
            var handlerMethod = ctx.CurrentDecleration.protected_virtual_func(null, Name);

            var methodInvoke = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), handlerMethod.Name);
            if (ctx.IsDesignerFile && EventHandler != null)
            {
                var eventType = EventHandler.SourceItem as Invert.ECS.Graphs.EventsChildItem;

                if (eventType.RelatedType == "void")
                {
                    return;
                }
                ctx._("var eventData = ({0})e.Data", eventType.RelatedTypeName);
                handlerMethod.Parameters.Add(
                        new CodeParameterDeclarationExpression(eventType.RelatedTypeName, "data"));
                methodInvoke.Parameters.Add(new CodeSnippetExpression("eventData"));
                
            }

            foreach (var item in RequiredComponents.Concat(LeftNodes.OfType<EventHandlerNode>().SelectMany(p=>p.RequiredComponents)))
            {
                var isArray = item.SourceVariable is CollectionsChildItem;
                var needsTryGet = item.Node == this;
                var componentOutput = item.Component;
                if (componentOutput != null)
                {
                    //var variableStart = item.Name.Split('.').Last();
                    //variableStart = variableStart.Substring(0, 1).ToLower() + variableStart.Substring(1);
                    //if (variableStart.ToLower().EndsWith("id"))
                    //{
                    //    variableStart = variableStart.Substring(0, variableStart.Length - 2);
                    //}
                    var componentVariable = componentOutput.ClassName.ToLower();
                    if (ctx.IsDesignerFile)
                    {
                        if (needsTryGet)
                        {
                            if (isArray)
                            {
                                ctx._("{0}[] {1}", componentOutput.ClassName, componentVariable);
                            }
                            else
                            {
                                ctx._("{0} {1}", componentOutput.ClassName, componentVariable);
                            }

                            ctx._if("!Game.ComponentSystem.TryGetComponent<{0}>({1}, out {2})",componentOutput.ClassName,
                                item.Name, componentVariable)
                                .TrueStatements.Add(new CodeMethodReturnStatement());
                        }

                        methodInvoke.Parameters.Add(new CodeSnippetExpression(componentVariable));
                    }

                    handlerMethod.Parameters.Add(
                        new CodeParameterDeclarationExpression(string.Format("{0}{1}", componentOutput.ClassName, (isArray ? "[]" : "")), componentVariable));
                }
            }
            if (!ctx.IsDesignerFile)
            {
                handlerMethod.invoke_base();
                handlerMethod.Attributes |= MemberAttributes.Override;
            }
            else
            {
                ctx.CurrentStatements.Add(methodInvoke);
            }
            base.WriteCode(ctx);
        }
    }

    public class VariableSelectionCommand<T> : EditorCommand<ActionNode> where T : GenericReferenceItem, new()
    {
        public override void Perform(ActionNode node)
        {
            InvertGraphEditor.WindowManager.InitItemWindow(node.AllContextVariables, _ =>
            {
                var item = new T()
                {
                    Node = node,
                    Name = _.VariableName,
                    SourceIdentifier = _.SourceVariable.Identifier
                };
                node.Project.AddItem(item);
            });
        }

        public override string CanPerform(ActionNode node)
        {
            return null;
        }
    }


}
