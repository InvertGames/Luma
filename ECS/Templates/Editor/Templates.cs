using System;
using System.CodeDom;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Invert.Core;
using Invert.Core.GraphDesigner;
using UnityEditor;


namespace Invert.ECS
{
    using Invert.ECS.Graphs;
    using Invert.ECS.Unity;
    public class ECSTemplates : DiagramPlugin
    {
        public override void Initialize(uFrameContainer container)
        {
            ECSPlugin = container.Resolve<uFrameECS>();

            ECSPlugin.Component.AddCodeTemplate<UnityComponentTemplate>();
            ECSPlugin.Component.AddCodeTemplate<VanillaComponentTemplate>();
            ECSPlugin.Component.AddCodeTemplate<ComponentInterfaceTemplate>();
            ECSPlugin.Component.AddCodeTemplate<UnityComponentTemplatePartial>();
            ECSPlugin.Component.AddCodeTemplate<ComponentAssetTemplate>();
            //ECSPlugin.Entity.AddCodeTemplate<EntityAssetTemplate>();
            ECSPlugin.System.AddCodeTemplate<SystemTemplate>();
            
            //ECSPlugin.System.AddCodeTemplate<SystemSignals>();

            ECSPlugin.Event.AddCodeTemplate<EventClassTemplate>();
            ECSPlugin.System.AddCodeTemplate<SystemsEventEnum>();
            ECSPlugin.Component.AddCodeTemplate<EntityEditorExtensionsTemplate>();

        }

        public uFrameECS ECSPlugin { get; set; }
    }

    public class ComponentTemplate : IClassTemplate<Invert.ECS.Graphs.ComponentNode>
    {

        public virtual void TemplateSetup()
        {
            foreach (var property in Ctx.Data.Properties)
            {
                var type = InvertApplication.FindTypeByName(property.RelatedTypeName);
                if (type == null) continue;
                Ctx.TryAddNamespace(type.Namespace);
            }
            foreach (var property in Ctx.Data.Collections)
            {
                var type = InvertApplication.FindTypeByName(property.RelatedTypeName);
                if (type == null) continue;
                Ctx.TryAddNamespace(type.Namespace);
            }
            Ctx.AddIterator("ComponentProperty", _ => _.Properties.Where(p => !p.Precompiled));
            Ctx.AddIterator("ComponentCollection", _ => _.Collections.Where(p => !p.Precompiled));



        }

        public TemplateContext<ComponentNode> Ctx { get; set; }

        [TemplateProperty(MemberGeneratorLocation.DesignerFile, "{0}", AutoFillType.NameOnly)]
        public virtual int ComponentProperty
        {
            get
            {

                Ctx.SetType(Ctx.TypedItem.RelatedTypeName );
                var field = Ctx.CurrentDecleration._private_(Ctx.TypedItem.RelatedTypeName, "_{0}", Ctx.Item.Name);
                
                field.CustomAttributes.Add(
                    new CodeAttributeDeclaration(typeof(SerializeField).ToCodeReference()));
                Ctx._("return {0}", field.Name);
                return 0;
            }
            set
            {
                Ctx._("_{0} = value", Ctx.Item.Name);
            }
        }

        [TemplateProperty(MemberGeneratorLocation.DesignerFile, "{0}", AutoFillType.NameOnly)]
        public virtual int ComponentCollection
        {
            get
            {

                var typeName = Ctx.TypedItem.RelatedTypeName + "[]";
                Ctx.SetType(typeName);
                var field = Ctx.CurrentDecleration._private_(typeName, "_{0}", Ctx.Item.Name);
                field.CustomAttributes.Add(
                   new CodeAttributeDeclaration(typeof(SerializeField).ToCodeReference()));
              
                Ctx._("return {0}", field.Name);
                return 0;
            }
            set
            {
                Ctx._("_{0} = value", Ctx.Item.Name);
            }
        }

    }

    [TemplateClass("Interfaces", MemberGeneratorLocation.DesignerFile, ClassNameFormat = "I{0}")]
    public class ComponentInterfaceTemplate : ComponentTemplate
    {
        public override void TemplateSetup()
        {
            base.TemplateSetup();
            Ctx.CurrentDecleration.BaseTypes.Clear();
            Ctx.CurrentDecleration.IsInterface = true;
        }
    }

    [TemplateClass("Data", MemberGeneratorLocation.DesignerFile, ClassNameFormat = "{0}Data")]
    public class VanillaComponentTemplate : ComponentTemplate
    {
        public override void TemplateSetup()
        {
            base.TemplateSetup();
            
            Ctx.CurrentDecleration.BaseTypes.Clear();
            Ctx.CurrentDecleration.BaseTypes.Add(string.Format("I{0}", Ctx.Data.Name).ToCodeReference());
            Ctx.CurrentDecleration.CustomAttributes.Add(
                new CodeAttributeDeclaration(typeof(SerializableAttribute).ToCodeReference()));

        }
    }

    [TemplateClass("Assets", MemberGeneratorLocation.Both, ClassNameFormat = "{0}Asset")]
    public class ComponentAssetTemplate : IClassTemplate<ComponentNode>
    {
        public void TemplateSetup()
        {
            Ctx.Namespace.Name = "";
            Ctx.CurrentDecleration.Name = Ctx.Data.Name + "Asset";
            Ctx.CurrentDecleration.IsPartial = true;
            Ctx.CurrentDecleration.BaseTypes.Clear();
            Ctx.CurrentDecleration.BaseTypes.Add(typeof(ComponentAsset).ToCodeReference());
            if (Ctx.IsDesignerFile)
            {
            //    Ctx.CurrentDecleration.CustomAttributes.Add(new CodeAttributeDeclaration(typeof(SerializableAttribute).ToCodeReference()));
            }
            foreach (var property in Ctx.Data.Properties)
            {
                var type = InvertApplication.FindTypeByName(property.RelatedTypeName);
                if (type == null) continue;
                Ctx.TryAddNamespace(type.Namespace);
            }
            foreach (var property in Ctx.Data.Collections)
            {
                var type = InvertApplication.FindTypeByName(property.RelatedTypeName);
                if (type == null) continue;
                Ctx.TryAddNamespace(type.Namespace);
            }
            Ctx.AddIterator("ComponentProperty", _ => _.Properties.Where(p => !p.Precompiled));
            Ctx.AddIterator("ComponentCollection", _ => _.Collections.Where(p => !p.Precompiled));

            
        }
        [TemplateProperty(MemberGeneratorLocation.DesignerFile, "{0}", AutoFillType.NameOnly)]
        public virtual int ComponentProperty
        {
            get
            {
                var componentNode = Ctx.Item.OutputTo<ComponentNode>();
                var type = componentNode == null ? Ctx.TypedItem.RelatedTypeName : componentNode.Name + "Asset";

                Ctx.SetType(type);
                var field = Ctx.CurrentDecleration._private_(type, "_{0}", Ctx.Item.Name);

                field.CustomAttributes.Add(
                    new CodeAttributeDeclaration(typeof(SerializeField).ToCodeReference()));
                Ctx._("return {0}", field.Name);
                return 0;
            }
            set
            {
                Ctx._("_{0} = value", Ctx.Item.Name);
            }
        }

        [TemplateProperty(MemberGeneratorLocation.DesignerFile, "{0}", AutoFillType.NameOnly)]
        public virtual int ComponentCollection
        {
            get
            {
                var componentNode = Ctx.Item.OutputTo<ComponentNode>();
                var type = componentNode == null ? Ctx.TypedItem.RelatedTypeName : componentNode.Name + "Asset";

                var typeName = type + "[]";
                Ctx.SetType(typeName);
                var field = Ctx.CurrentDecleration._private_(typeName, "_{0}", Ctx.Item.Name);
                field.CustomAttributes.Add(
                   new CodeAttributeDeclaration(typeof(SerializeField).ToCodeReference()));

                Ctx._("return {0}", field.Name);
                return 0;
            }
            set
            {
                Ctx._("_{0} = value", Ctx.Item.Name);
            }
        }

        public TemplateContext<ComponentNode> Ctx { get; set; }
    }

    [TemplateClass("Components", MemberGeneratorLocation.Both, ClassNameFormat = "{0}")]
    public class UnityComponentTemplate : ComponentTemplate
    {
        public override void TemplateSetup()
        {
            base.TemplateSetup();
            if (Ctx.IsDesignerFile)
            {
                Ctx.SetBaseType(typeof (UnityComponent));
                Ctx.CurrentDecleration.BaseTypes.Add(string.Format("I{0}", Ctx.Data.Name).ToCodeReference());

                var field = Ctx.CurrentDecleration._private_(string.Format("{0}Asset", Ctx.Data.Name), "_Asset");
                field.CustomAttributes.Add(new CodeAttributeDeclaration(typeof (SerializeField).ToCodeReference()));
                field.CustomAttributes.Add(new CodeAttributeDeclaration(typeof (HideInInspector).ToCodeReference()));

            }
            else
            {
                Ctx.CurrentDecleration.IsPartial = true;
      
            }
            
        }
        [TemplateProperty(MemberGeneratorLocation.DesignerFile)]
        public ComponentAsset Asset
        {
            get
            {
                Ctx.SetType(string.Format("{0}Asset", Ctx.Data.Name));
                Ctx._("return _Asset");
                return null;
            }
            set { Ctx._("_Asset = value"); }
        }
        [TemplateMethod(MemberGeneratorLocation.DesignerFile)]
        public void Awake()
        {
            Ctx.PushStatements(Ctx._if("_Asset != null").TrueStatements);

            Ctx.CurrentMethod.Attributes = MemberAttributes.Override | MemberAttributes.Public; 
            foreach (var item in Ctx.Data.Properties)
            {
                var componentNode = item.OutputTo<ComponentNode>();
                if (componentNode != null)
                {
                    Ctx._("{0} = _Asset.{0}.EntityId", item.Name);
                }
                else
                {
                    Ctx._("{0} = _Asset.{0}", item.Name);
                }
                
            }
            foreach (var item in Ctx.Data.Collections)
            {
                var componentNode = item.OutputTo<ComponentNode>();
                if (componentNode != null)
                {
                    Ctx._("{0} = _Asset.{0}.Select(p=>p.EntityId).ToArray()", item.Name);
                }
                else
                {
                    Ctx._("{0} = _Asset.{0}", item.Name);
                }
              
            }
            Ctx.PopStatements();
        }

    }

     [TemplateClass("Components", MemberGeneratorLocation.DesignerFile, ClassNameFormat = "{0}")]
    public class UnityComponentTemplatePartial : IClassTemplate<Invert.ECS.Graphs.ComponentNode>
    {
         public void TemplateSetup()
         {
             Ctx.CurrentDecleration.BaseTypes.Clear();
             Ctx.CurrentDecleration.IsPartial = true;
             Ctx.CurrentDecleration.Name = Ctx.Data.Name;
             var system =
          Ctx.Data.Project.Graphs.SelectMany(p => p.NodeItems.OfType<SystemNode>())
              .FirstOrDefault(p => p.SystemComponents.Contains(Ctx.Data));
             if (system != null)
             {
                 Ctx.CurrentDecleration.CustomAttributes.Add(new CodeAttributeDeclaration(
                     new CodeTypeReference(typeof(AddComponentMenu)),
                     new CodeAttributeArgument(
                         new CodePrimitiveExpression(string.Format("{0}/{1}", system.Name, Ctx.Data.Name)))));
             }

         }

         public TemplateContext<ComponentNode> Ctx { get; set; }
    }
   
    [TemplateClass("Events", MemberGeneratorLocation.Both, ClassNameFormat = "{0}")]
    public class EventClassTemplate : IClassTemplate<Invert.ECS.Graphs.EventNode>
    {
        public void TemplateSetup()
        {
            foreach (var property in Ctx.Data.Properties)
            {
                var type = InvertApplication.FindTypeByName(property.RelatedTypeName);
                if (type == null) continue;
                Ctx.TryAddNamespace(type.Namespace);
            }
            foreach (var property in Ctx.Data.Collections)
            {
                var type = InvertApplication.FindTypeByName(property.RelatedTypeName);
                if (type == null) continue;
                Ctx.TryAddNamespace(type.Namespace);
            }
            Ctx.AddIterator("ComponentProperty", _ => _.Properties);
            Ctx.AddIterator("ComponentCollection", _ => _.Collections);
        }

        public TemplateContext<EventNode> Ctx { get; set; }

        [TemplateProperty(MemberGeneratorLocation.DesignerFile, "{0}", AutoFillType.NameOnly)]
        public int ComponentProperty
        {
            get
            {

                Ctx.SetType(Ctx.TypedItem.RelatedTypeName);
                var field = Ctx.CurrentDecleration._private_(Ctx.TypedItem.RelatedTypeName, "_{0}", Ctx.Item.Name);

                Ctx._("return {0}", field.Name);
                return 0;
            }
            set
            {
                Ctx._("_{0} = value", Ctx.Item.Name);
            }
        }

        [TemplateProperty(MemberGeneratorLocation.DesignerFile, "{0}", AutoFillType.NameOnly)]
        public int ComponentCollection
        {
            get
            {

                var typeName = Ctx.TypedItem.RelatedTypeName + "[]";
                var field = Ctx.CurrentDecleration._private_(typeName, "_{0}", Ctx.Item.Name);
                Ctx.SetType(typeName);
                Ctx._("return {0}", field.Name);
                return 0;
            }
            set
            {
                Ctx._("_{0} = value", Ctx.Item.Name);
            }
        }

    }

    [TemplateClass("Systems", MemberGeneratorLocation.Both, ClassNameFormat = "{0}")]
    public class SystemTemplate : IClassTemplate<SystemNode>
    {

        [TemplateMethod(MemberGeneratorLocation.DesignerFile,false)]
        public virtual void Initialize(IGame game)
        {
            Ctx.CurrentMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            Ctx.CurrentMethod.invoke_base();
            if (Ctx.IsDesignerFile)
            {
                foreach (var sc in Ctx.Data.SystemComponents)
                {
                    Ctx._("{0}Manager = game.ComponentSystem.RegisterComponent<{0}>()",sc.Name);
                }
                foreach (var item in Ctx.Data.Handlers)
                {
                    if (item.SourceItem == null)
                    {
                        InvertApplication.Log(string.Format("{0} on node {1} is not available", item.Name, item.Node.Name));
                        continue;
                    }
                    var relatedNode = item.SourceItem.Node;
                    var eventsName = relatedNode.Name + "Events";
                    Ctx._("game.EventManager.ListenFor( {0}.{1}, {2} )", eventsName, item.SourceItem.Name, item.Name);
                }

            }
            else
            {
                Ctx.CurrentDecleration.Comments.Add(
                    new CodeCommentStatement("Base class initializes the event listeners."));
            }
        

        }
        [TemplateProperty(MemberGeneratorLocation.DesignerFile,"{0}Manager",AutoFillType.NameOnlyWithBackingField)]
        public object ComponentManager
        {
            get
            {
                Ctx.SetType("ComponentManager<{0}>",Ctx.Item.Name);
                return null;
            }
        }
        [TemplateMethod(MemberGeneratorLocation.DesignerFile, AutoFill = AutoFillType.NameOnly, CallBase = true)]
        protected virtual void Handler(IEvent e)
        {

            if (!Ctx.IsDesignerFile) return;
            var systemEventHandlerReference = Ctx.ItemAs<SystemEventHandlerReference>();
            if (systemEventHandlerReference != null)
            {
                var eventHandlerNodes = systemEventHandlerReference.OutputsTo<EventHandlerNode>();
                foreach (var eventHandlerNode in eventHandlerNodes)
                {

                    Ctx._("{0}(e)", eventHandlerNode.Name);
                }

            }
        }
        [TemplateMethod(MemberGeneratorLocation.Both, AutoFill = AutoFillType.NameOnly, CallBase = true)]
        protected virtual void EventHandler(IEvent e)
        {
            var systemEventHandlerReference = Ctx.Item.InputFrom<SystemEventHandlerReference>();
            var eventHandlerNode = Ctx.ItemAs<EventHandlerNode>();
            if (!Ctx.IsDesignerFile)
            {
                Ctx.CurrentDecleration.Members.Remove(Ctx.CurrentMethod);
                return;
            }
                
            var right = eventHandlerNode;
            eventHandlerNode.WriteCode(Ctx);
            return;
            DoHandlerMethod(right, systemEventHandlerReference);
            


        }
        private void DoHandlerMethod(EventHandlerNode eventHandlerNode, SystemEventHandlerReference systemEventHandlerReference)
        {
            eventHandlerNode.WriteCode(Ctx);
            //return;
            //var eventType = systemEventHandlerReference.SourceItem as Invert.ECS.Graphs.EventTypeChildItem;

            //if (eventType.RelatedType == "void")
            //{

            //    return;
            //}

            //var handlerMethod = Ctx.CurrentDecleration.protected_virtual_func(null, eventHandlerNode.Name,
            //    eventType.RelatedTypeName, "data");
            //var right = eventHandlerNode;
            //var methodInvoke = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), handlerMethod.Name);
            //if (Ctx.IsDesignerFile)
            //{
            //    Ctx._("var data = ({0})e.Data", eventType.RelatedTypeName);
            //    methodInvoke.Parameters.Add(new CodeSnippetExpression("data"));
            //}
            //while (right != null)
            //{
            //    var previous = right.Left;
            //    var previousOutputs = new List<ComponentNode>();
            //    foreach (var item in right.Outputs)
            //    {
            //        var isArray = item.SourceItem is ComponentCollectionChildItem;

            //        var dataVarName = "data";
            //        if (previous != null)
            //        {
            //            var leftMapping =
            //                previous.Outputs.FirstOrDefault(
            //                    p => p.OutputTo<ComponentNode>() == item.SourceItem.Node);
            //            if (leftMapping != null)
            //            {
            //                dataVarName = leftMapping.Name.ToLower();
            //            }
            //        }

            //        var componentOutput = item.OutputTo<ComponentNode>();
            //        if (componentOutput != null)
            //        {
            //            if (Ctx.IsDesignerFile)
            //            {

            //                if (isArray)
            //                {
            //                    Ctx._("{0}[] {1}", componentOutput.ClassName, item.Name.ToLower());
            //                }
            //                else
            //                {
            //                    Ctx._("{0} {1}", componentOutput.ClassName, item.Name.ToLower());
            //                }
                            
            //                Ctx._if("!Game.ComponentSystem.TryGetComponent<{0}>({3}.{1}, out {2})", componentOutput.ClassName,
            //                    item.SourceItem.Name, item.Name.ToLower(), dataVarName)
            //                    .TrueStatements.Add(new CodeMethodReturnStatement());
            //                methodInvoke.Parameters.Add(new CodeSnippetExpression(item.Name.ToLower()));
            //            }

            //            handlerMethod.Parameters.Add(
            //                new CodeParameterDeclarationExpression(string.Format("{0}{1}", componentOutput.ClassName, (isArray ? "[]" : "")), item.Name.ToLower()));
            //        }
            //        else
            //        {
            //            var relatedTypeItem = (item.SourceItem as ITypedItem);
            //            handlerMethod.Parameters.Add(
            //                new CodeParameterDeclarationExpression(relatedTypeItem.RelatedTypeName, item.Name.ToLower()));
            //            if (Ctx.IsDesignerFile)
            //            {
            //                methodInvoke.Parameters.Add(new CodeSnippetExpression(string.Format("{0}.{1}", dataVarName, item.SourceItem.Name)));
            //            }
            //        }
            //        previousOutputs.Add(componentOutput);
            //    }

            //    right = right.Right;
            //}
            //if (!Ctx.IsDesignerFile)
            //{
            //    handlerMethod.invoke_base();
            //    handlerMethod.Attributes |= MemberAttributes.Override;
            //}
            //else
            //{
            //    Ctx.CurrentMethod.Statements.Add(methodInvoke);
            //}

        }

        public virtual void Destroy()
        {
         
        }

        public virtual void TemplateSetup()
        {
            Ctx.AddIterator("Handler", _ => _.Handlers);
            Ctx.AddIterator("EventHandler", _ => _.Handlers.SelectMany(p => p.OutputsTo<EventHandlerNode>()).Distinct());
            Ctx.AddIterator("EventSignaler", _ => _.Events);
            Ctx.AddIterator("EventSignalerStatic", _ => _.Events);
            Ctx.AddIterator("ComponentManager", _ => _.SystemComponents);
            if (Ctx.IsDesignerFile)
            {
                //if (Ctx.Data.UnitySystem)
                //{
                this.Ctx.SetBaseType("UnitySystem");
                //}
                //else
                //{
                //    this.Ctx.SetBaseType("SystemBase");
                //}
            }

        }

        public TemplateContext<SystemNode> Ctx { get; set; }

        [TemplateMethod(MemberGeneratorLocation.DesignerFile, AutoFill = AutoFillType.NameOnly, NameFormat = "Signal{0}")]
        public void EventSignaler(object data)
        {
            Ctx.CurrentMethod.Parameters[0].Type = Ctx.ItemAs<EventTypeChildItem>().RelatedTypeName.ToCodeReference();
            Ctx._("Game.EventManager.SignalEvent(new EventData({0}Events.{1},data))", Ctx.Data.Name, Ctx.Item.Name);
        }
        [TemplateMethod(MemberGeneratorLocation.DesignerFile, AutoFill = AutoFillType.NameOnly, NameFormat = "Signal{0}")]
        public void EventSignalerStatic()
        {
            Ctx.CurrentMethod.Attributes = MemberAttributes.Static | MemberAttributes.Public;
            
            Ctx.CurrentMethod.Parameters.Add(new CodeParameterDeclarationExpression("IGame",
           "game"));

            Ctx.CurrentMethod.Parameters.Add(new CodeParameterDeclarationExpression(Ctx.ItemAs<EventTypeChildItem>().RelatedTypeName.ToCodeReference(),
                "data"));

            Ctx._("game.EventManager.SignalEvent(new EventData({0}Events.{1},data))", Ctx.Data.Name, Ctx.Item.Name);
        }
    }

    //[TemplateClass("Systems", MemberGeneratorLocation.DesignerFile, ClassNameFormat = "{0}Signals")]
    //public class SystemSignals : IClassTemplate<SystemNode>
    //{
    //    public void TemplateSetup()
    //    {
    //        Ctx.CurrentDecleration.MakeStatic();
    //        Ctx.AddIterator("Signal",_=>_.Events);
    //    }
    //    [TemplateMethod(MemberGeneratorLocation.DesignerFile,AutoFill=AutoFillType.NameOnly,NameFormat = "Signal{0}")]
    //    public void Signal()
    //    {
    //        Ctx.CurrentMethod.Attributes = MemberAttributes.Static | MemberAttributes.Public;
    //        Ctx.CurrentMethod.Parameters.Add(new CodeParameterDeclarationExpression("this ISystem",
    //            "system")); 
    //        Ctx.CurrentMethod.Parameters.Add(new CodeParameterDeclarationExpression(Ctx.ItemAs<EventTypeChildItem>().RelatedTypeName.ToCodeReference(),
    //            "data"));

            
    //        Ctx._("system.Game.EventManager.SignalEvent(new EventData({0}Events.{1},data))", Ctx.Data.Name, Ctx.Item.Name);
    //        //Ctx.CurrentMethod

    //    }
    //    //[TemplateMethod(MemberGeneratorLocation.DesignerFile, AutoFill = AutoFillType.NameOnly, NameFormat = "Signal{0}")]
    //    //public void SignalA()
    //    //{
    //    //    Ctx.CurrentMethod.Attributes = MemberAttributes.Static | MemberAttributes.Public;
    //    //    Ctx.CurrentMethod.Parameters.Add(new CodeParameterDeclarationExpression("this IGame",
    //    //        "game"));

    //    //    var eventType = Ctx.ItemAs<EventTypeChildItem>().RelatedTypeNode as EventNode;
    //    //    if (eventType == null) return;
    //    //    var sb = new StringBuilder();
    //    //    foreach (var item in eventType.Properties)
    //    //    {
    //    //        Ctx.CurrentMethod.Parameters.Add(new CodeParameterDeclarationExpression(item.RelatedTypeName, item.Name));
    //    //    }
    //    //    foreach (var item in eventType.Properties)
    //    //    {
    //    //        Ctx.CurrentMethod.Parameters.Add(new CodeParameterDeclarationExpression(item.RelatedTypeName + "[]", item.Name));
    //    //    }

    //    //    Ctx._("game.EventManager.SignalEvent(new EventData({0}Events.{1}, new {0}({2}));", Ctx.Data.Name, Ctx.Item.Name);
    //    //    //Ctx.CurrentMethod

    //    //}
    //    public TemplateContext<SystemNode> Ctx { get; set; }
    //}

    [TemplateClass("Enums", "{0}Events", MemberGeneratorLocation.DesignerFile, AutoInherit = false)]
    public class SystemsEventEnum : IClassTemplate<SystemNode>
    {
        public void TemplateSetup()
        {
            Ctx.CurrentDecleration.IsEnum = true;
            Ctx.CurrentDecleration.BaseTypes.Clear();
            foreach (var item in Ctx.Data.Events)
            {
                this.Ctx.CurrentDecleration.Members.Add(new CodeMemberField(this.Ctx.CurrentDecleration.Name, item.Name));
            }
        }

        public TemplateContext<SystemNode> Ctx { get; set; }
    }

    [TemplateClass("Assets", "{0}Entity", MemberGeneratorLocation.DesignerFile, AutoInherit = false, IsEditorExtension = true)]
    public class EntityAssetTemplate : IClassTemplate<EntityNode>
    {
        public void TemplateSetup()
        {
            Ctx.CurrentDecleration.BaseTypes.Clear();
            Ctx.CurrentDecleration.BaseTypes.Add(typeof(ScriptableObject));
            Ctx.AddIterator("ComponentData", _ => _.Components);
        }

        public TemplateContext<EntityNode> Ctx { get; set; }

        [TemplateProperty(MemberGeneratorLocation.DesignerFile, AutoFillType.NameOnly)]
        public object ComponentData
        {
            get
            {
                var type = Ctx.ItemAs<EntityComponentsReference>().SourceItem.Name + "Data";
                Ctx.SetType(type);
                var field = Ctx.CurrentDecleration._private_(type, "_" + Ctx.Item.Name);
                field.CustomAttributes.Add(new CodeAttributeDeclaration(typeof(SerializeField).ToCodeReference()));
                Ctx._("return {0}", "_" + Ctx.Item.Name);
                return null;
            }
        }
    }

    [TemplateClass("Extensions", "{0}MenuItems", MemberGeneratorLocation.DesignerFile, AutoInherit = false, IsEditorExtension = true)]
    public class EntityEditorExtensionsTemplate : IClassTemplate<ComponentNode>
    {
        public void TemplateSetup()
        {
            Ctx.TryAddNamespace("Invert.ECS.Graphs");
            //Ctx.CurrentDecleration.Name = "static " + 
            //Ctx.AddIterator("CreateComponent", _ => Ctx.Data.Graph.NodeItems.OfType<ComponentNode>());
        }

        public TemplateContext<ComponentNode> Ctx { get; set; }

        [TemplateMethod("Create{0}", MemberGeneratorLocation.DesignerFile, false)]
        public void CreateComponent()
        {
            Ctx.CurrentMethod.Attributes |= MemberAttributes.Static;
            Ctx.CurrentMethod.CustomAttributes.Add(new CodeAttributeDeclaration(typeof(MenuItem).ToCodeReference(),
                new CodeAttributeArgument(
                    new CodePrimitiveExpression(string.Format("Assets/{0}/{1}", Ctx.Data.Graph.Name,
                        Ctx.Item.Name))), 
                        new CodeAttributeArgument(new CodePrimitiveExpression(false)),
                        new CodeAttributeArgument(new CodePrimitiveExpression(-1))
                        ));
            Ctx._("uFrameECS.CreateAsset<{0}Asset>()", Ctx.Item.Name);
        }
    }



}
