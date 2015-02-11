using Invert.uFrame.Editor;

namespace Invert.ECS.Graphs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;

    public class uFrameECS : uFrameECSBase
    {
        
        public override Invert.Core.GraphDesigner.SelectItemTypeCommand GetComponentPropertySelectionCommand()
        {
            base.GetComponentPropertySelectionCommand();
            return new SelectItemTypeCommand() { IncludePrimitives = true, AllowNone = false };
        }

        public override Invert.Core.GraphDesigner.SelectItemTypeCommand GetComponentCollectionSelectionCommand()
        {
            base.GetComponentCollectionSelectionCommand();
            return new SelectItemTypeCommand() { IncludePrimitives = true, AllowNone = false };
        }

        public override SelectItemTypeCommand GetEventTypeSelectionCommand()
        {
            var command = base.GetEventTypeSelectionCommand();
            command.AllowNone = true;
            return command;
        }

        public override void Initialize(Invert.Core.uFrameContainer container)
        {
            base.Initialize(container);
            container.Connectable<EventHandlerEntityMappingReference, ComponentNode>();
            container.Connectable<EventHandlerNode, EventHandlerNode>();
            container.Connectable<ActionNode, ActionNode>();

            var typeContainer = InvertGraphEditor.TypesContainer;
            typeContainer.RegisterInstance(new GraphTypeInfo() {  Group = "",Name="ENTITY", Label = "ENTITY", IsPrimitive = true }, "ENTITY");
            typeContainer.RegisterInstance(new GraphTypeInfo() { Type=typeof(UnityEngine.Color), Group = "",Name="Color", Label = "Color", IsPrimitive = true }, "Color");
            System.AddFlag("Unity System");
            EventHandler.Name = "Event Handler";
            Systems.HasSubNode<EnumNode>();
            System.HasSubNode<EnumNode>();

            var systemsGraph = CreatePrecompiledSystemsGraph("Framework");
            var unityGraph = CreatePrecompiledSystemsGraph("Unity");
            
            //Action.LoadDerived<ActionNodeViewModel>();

            DefaultProjectRepository.AddPrecompiledGraph(systemsGraph);
            DefaultProjectRepository.AddPrecompiledGraph(unityGraph);
            EventHandler.HasSubNode<ActionNode>();
            container.AddTypeItem<ComponentPropertyChildItem, ComponentPropertyChildViewModel, ComponentPropertyDrawer>();
            container.AddTypeItem<ComponentCollectionChildItem, ComponentCollectionChildViewModel, ComponentCollectionDrawer>();
            container.AddItem<PropertyMappingsReference, PropertyMappingsReferenceViewModel, PropertyMappingsReferenceDrawer>();
            //container.AddItem<VariableTypeSlot, InputOutputViewModel, SlotDrawer>();
            container.RegisterDrawer<ItemSelectionPropertyViewModel, ItemSelectionPropertyDrawer>();
            systemsGraph.AddNode(
                CreatePrecompiledNode<EventNode>("ComponentEventData",
                    CreateTypedChild<ComponentPropertyChildItem>(typeof(IComponent).Name, "Component")
                ));
            systemsGraph.AddNode(
                CreatePrecompiledNode<EventNode>("EntityEventData",
                    CreateTypedChild<ComponentPropertyChildItem>("ENTITY", "EntityId")
                ));
            unityGraph.AddNode(
                CreatePrecompiledNode<EventNode>("CollisionEventData",
                    CreateTypedChild<ComponentPropertyChildItem>("ENTITY", "ColliderId"),
                    CreateTypedChild<ComponentPropertyChildItem>("ENTITY", "CollideeId")
                ));


            unityGraph.AddNode(
                CreatePrecompiledNode<EventNode>("MouseEventData",
                    CreateTypedChild<ComponentPropertyChildItem>("ENTITY", "EntityId")
                ));

            var node = CreatePrecompiledNode<SystemNode>("Framework",
                CreateTypedChild<EventTypeChildItem>( "IComponent", "ComponentCreated"),
                CreateTypedChild<EventTypeChildItem>( "IComponent", "ComponentDestroyed"),
                CreateTypedChild<EventTypeChildItem>("LoadingProgressData", "LoadingProgress"),
                CreateTypedChild<EventTypeChildItem>("ENTITY", "EntityDestroyed"),
                CreateTypedChild<EventTypeChildItem>("void", "Loaded")
                );
            systemsGraph.AddNode(node);

            var unityGraphNode = CreatePrecompiledNode<SystemNode>("Unity",
                CreateTypedChild<EventTypeChildItem>( "CollisionEventData", "CollisionEnter"),
                CreateTypedChild<EventTypeChildItem>( "CollisionEventData", "CollisionStay"),
                CreateTypedChild<EventTypeChildItem>( "CollisionEventData", "CollisionExit"),
                CreateTypedChild<EventTypeChildItem>( "CollisionEventData", "TriggerEnter"),
                CreateTypedChild<EventTypeChildItem>( "CollisionEventData", "TriggerStay"),
                CreateTypedChild<EventTypeChildItem>( "CollisionEventData", "TriggerExit"),
                CreateTypedChild<EventTypeChildItem>( "MouseEventData", "MouseDown"),
                CreateTypedChild<EventTypeChildItem>( "MouseEventData", "MouseUp")
                );
            unityGraph.AddNode(unityGraphNode);

        }

        private static SystemsGraph CreatePrecompiledSystemsGraph(string name)
        {
            var systemsGraph = new SystemsGraph()
            {
                Name = name,
                Identifier = name,
                Precompiled = true
            };
            systemsGraph.Prepare();
            return systemsGraph;
        }

        public T CreatePrecompiledNode<T>(string name, params ITypedItem[] items) where T : GenericNode, new()
        {
            var evtData = new T()
            {
                Identifier = name,
                Name = name,
                Precompiled = true,
                ChildItems = items.Cast<IDiagramNodeItem>().ToList()
            };
            foreach (var childItem in items)
            {
                childItem.Node = evtData;
            }
            return evtData;
        }

        public T CreateTypedChild<T>(string type, string name) where T : GenericTypedChildItem, new()
        {
            return CreateTypedChild<T>(null, type, name);
        }

        public T CreateTypedChild<T>(GenericNode node, string type, string name) where T : GenericTypedChildItem, new()
        {
            return new T()
            {
                RelatedType = type,
                Name = name,
                Node = node,
                Precompiled = true,
                Identifier = name
            };
        }
    }

    public static class uFrameECSHelpers
    {
        
    }


}
