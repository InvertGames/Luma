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
        public SystemEventHandlerReference EventHandler
        {
            get { return this.InputFrom<SystemEventHandlerReference>(); }
        }

        [ReferenceSection("Lookups", SectionVisibility.WhenNodeIsNotFilter, 
            true, false, typeof(IEventHandlerEntityMapping), true, 
            OrderIndex = 0, HasPredefinedOptions = false,
            AddCommandType = typeof(VariableSelectionCommand<EventHandlerEntityMappingReference>))]
        public override System.Collections.Generic.IEnumerable<EventHandlerEntityMappingReference> Outputs
        {
            get
            {
                return ChildItems.OfType<EventHandlerEntityMappingReference>();
            }
        }

        public EventTypeChildItem EventType
        {
            get
            {
                if (EventHandler == null) return null;
                return EventHandler.SourceItem as EventTypeChildItem;
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

        public override IEnumerable<IEventHandlerEntityMapping> PossibleOutputs
        {
            get
            {
                return AllContextVariables.OfType<IEntityEventHandlerMapping>().Where(p => p.IsEntity).Cast<IEventHandlerEntityMapping>();
               
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
                foreach (var output in Outputs)
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
                foreach (var item in this.Outputs)
                {
                    var component = item.OutputTo<ComponentNode>();
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
                var eventType = EventHandler.SourceItem as Invert.ECS.Graphs.EventTypeChildItem;

                if (eventType.RelatedType == "void")
                {
                    return;
                }
                ctx._("var eventData = ({0})e.Data", eventType.RelatedTypeName);
                handlerMethod.Parameters.Add(
                        new CodeParameterDeclarationExpression(eventType.RelatedTypeName, "data"));
                methodInvoke.Parameters.Add(new CodeSnippetExpression("eventData"));
                
            }

            foreach (var item in Outputs.Concat(LeftNodes.OfType<EventHandlerNode>().SelectMany(p=>p.Outputs)))
            {
                var isArray = item.SourceVariable is ComponentCollectionChildItem;
                var needsTryGet = item.Node == this;
                var componentOutput = item.OutputTo<ComponentNode>();
                if (componentOutput != null)
                {
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
