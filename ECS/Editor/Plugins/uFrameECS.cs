using System.Reflection;
using Invert.Core;
using Invert.uFrame.Editor;
using UnityEditor;
using UnityEngine;

namespace Invert.ECS.Graphs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;

    public class uFrameECS : uFrameECSBase, IPrefabNodeProvider
    {

        private static ECSUserSettings _userSettings;
        public static ECSUserSettings UserSettings
        {
            get { return _userSettings ?? (_userSettings = AssetDatabase.LoadAssetAtPath("Assets/UserSettings.asset", typeof(ECSUserSettings)) as ECSUserSettings); }
            set { _userSettings = value; }
        }

        public override Invert.Core.GraphDesigner.SelectItemTypeCommand GetPropertiesSelectionCommand()
        {
            base.GetPropertiesSelectionCommand();
            return new SelectItemTypeCommand() { IncludePrimitives = true, AllowNone = false };
        }

        public override Invert.Core.GraphDesigner.SelectItemTypeCommand GetCollectionsSelectionCommand()
        {
            base.GetCollectionsSelectionCommand();
            return new SelectItemTypeCommand() { IncludePrimitives = true, AllowNone = false };
        }

        public override SelectItemTypeCommand GetEventsSelectionCommand()
        {
            var command = base.GetEventsSelectionCommand();
            command.AllowNone = true;
            return command;
        }

        public static TAsset CreateAsset<TAsset>() where TAsset : ComponentAsset
        {
            if (UserSettings == null)
            {
                EditorUtility.DisplayDialog("Issue", "You need to create a user settings file first.", "OK");
                return null;
            }
            var asset = uFrameMenu.CreateAsset<TAsset>(null,typeof(TAsset).Name.Replace("Asset",""));
            asset.name = asset.name.Replace(" ", "");
            asset.EntityId = UserSettings.GetUniqueId();
            foreach (var plugin in InvertApplication.Plugins.OfType<ICreateAssetListener>())
            {
                plugin.AssetCreated(typeof(TAsset), asset);
            }
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
            return asset;
        }
        public override void Initialize(Invert.Core.uFrameContainer container)
        {
            base.Initialize(container);
            container.Connectable<RequiredComponentsReference, ComponentNode>();
            container.Connectable<EventHandlerNode, EventHandlerNode>();
            container.Connectable<ActionNode, ActionNode>();
           
            var typeContainer = InvertGraphEditor.TypesContainer;
            typeContainer.RegisterInstance(new GraphTypeInfo() {  Group = "",Name="ENTITY", Label = "ENTITY", IsPrimitive = true }, "ENTITY");
            typeContainer.RegisterInstance(new GraphTypeInfo() { Type=typeof(UnityEngine.Color), Group = "",Name="Color", Label = "Color", IsPrimitive = true }, "Color");
            System.AddFlag("Unity System");
            EventHandler.Name = "Event Handler";
            Systems.HasSubNode<EnumNode>();
            System.HasSubNode<EnumNode>();
            System.HasSubNode<TypeReferenceNode>();
            System.HasSubNode<ScreenshotNode>();
            Systems.HasSubNode<TypeReferenceNode>().HasSubNode<ScreenshotNode>();
            var systemsGraph = CreatePrecompiledSystemsGraph("Framework");

            var unityGraph = CreatePrecompiledSystemsGraph("Unity");
            
            //Action.LoadDerived<ActionNodeViewModel>();
//            container.RegisterItemDrawer<ScaffoldNodeChildItem<RequiredComponentsReference>.ViewModel, SlotDrawer>();

            DefaultProjectRepository.AddPrecompiledGraph(systemsGraph);
            DefaultProjectRepository.AddPrecompiledGraph(unityGraph);

            EventHandler.HasSubNode<ActionNode>();
            container.AddTypeItem<PropertiesChildItem, ComponentPropertyChildViewModel, ComponentPropertyDrawer>();
            container.AddTypeItem<CollectionsChildItem, ComponentCollectionChildViewModel, ComponentCollectionDrawer>();
            container.AddItem<PropertyMapsReference, PropertyMappingsReferenceViewModel, PropertyMappingsReferenceDrawer>();
            //container.AddItem<VariableTypeSlot, InputOutputViewModel, SlotDrawer>();
            container.RegisterDrawer<ItemSelectionPropertyViewModel, ItemSelectionPropertyDrawer>();


            systemsGraph.AddNode(
                CreatePrecompiledNode<EventNode>("ComponentEventData",
                    CreateTypedChild<PropertiesChildItem>(typeof(IComponent).Name, "Component")
                ));

            systemsGraph.AddNode(ImportEventClass<UIEventData>());
            systemsGraph.AddNode(ImportEventClass<IComponent>());
            systemsGraph.AddNode(ImportEventClass<MouseEventData>());
            systemsGraph.AddNode(ImportEventClass<EntityEventData>());
            systemsGraph.AddNode(ImportEventClass<CollisionEventData>());

            var node = CreatePrecompiledNode<SystemNode>("Framework",
                CreateTypedChild<EventsChildItem>( "IComponent", "ComponentCreated"),
                CreateTypedChild<EventsChildItem>( "IComponent", "ComponentDestroyed"),
                CreateTypedChild<EventsChildItem>("LoadingProgressData", "LoadingProgress"),
                CreateTypedChild<EventsChildItem>("ENTITY", "EntityDestroyed"),
                CreateTypedChild<EventsChildItem>("void", "Loaded")
                );
            systemsGraph.AddNode(node);

            var unityGraphNode = CreatePrecompiledNode<SystemNode>("Unity",
                CreateTypedChild<EventsChildItem>("CollisionEventData", "CollisionEnter"),
                CreateTypedChild<EventsChildItem>("CollisionEventData", "CollisionStay"),
                CreateTypedChild<EventsChildItem>("CollisionEventData", "CollisionExit"),
                CreateTypedChild<EventsChildItem>("CollisionEventData", "TriggerEnter"),
                CreateTypedChild<EventsChildItem>("CollisionEventData", "TriggerStay"),
                CreateTypedChild<EventsChildItem>("CollisionEventData", "TriggerExit"),
                CreateTypedChild<EventsChildItem>("MouseEventData", "MouseDown"),
                CreateTypedChild<EventsChildItem>("MouseEventData", "MouseUp")
            );

            var graphNode = CreatePrecompiledNode<SystemNode>("uGUI",
                CreateTypedChild<EventsChildItem>("UIEventData", "Click")
                );
            unityGraph.AddNode(graphNode);
            unityGraph.AddNode(unityGraphNode);
        }

        public EventNode ImportEventClass<TEventClass>()
        {
            var node =  ImportClass<EventNode, PropertiesChildItem, CollectionsChildItem>(typeof(TEventClass));
            foreach (var item in node.ChildItems.OfType<ITypedItem>())
            {
                if (item.Name == "EntityId" || item.RelatedType == typeof(int).Name)
                {
                    item.RelatedType = "ENTITY";
                }
            }
            return node;
        }

        public TNodeClass ImportClass<TNodeClass,TPropertiesType,TCollectionType>(Type classType) where TNodeClass : GenericNode, new() where TPropertiesType : GenericTypedChildItem, new() where TCollectionType : GenericTypedChildItem, new()
        {
            var properties = classType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var lst = new List<ITypedItem>();
            
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray || typeof (ICollection).IsAssignableFrom(property.PropertyType))
                {
                    lst.Add(CreateTypedChild<TCollectionType>(property.PropertyType.Name, property.Name));
                }
                else
                {
                    lst.Add(CreateTypedChild<TPropertiesType>(property.PropertyType.Name, property.Name));
                }
            }
            return CreatePrecompiledNode<TNodeClass>(classType.Name, lst.Cast<ITypedItem>().ToArray());

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

        public IEnumerable<QuickAddItem> PrefabNodes(INodeRepository nodeRepository)
        {
            var system = nodeRepository.CurrentFilter as SystemNode;
            if (system != null)
            {
                var eventChildItems = system.PossibleHandlers.OfType<EventsChildItem>().ToArray();
                foreach (var item in eventChildItems)
                {
                    var item1 = item;
                    var quickAddAction = new QuickAddItem("Listen For", item1.Name, _ =>
                    {
                        
                        var handlerReference = new HandlersReference()
                        {
                            Node = system,
                            SourceIdentifier = _.Item.Identifier
                        };
                        nodeRepository.AddItem(handlerReference);
                        var eventNode = new EventHandlerNode()
                        {
                            Name = _.Item.Name + "Handler",
                        };
                        _.Diagram.AddNode(eventNode, _.MousePosition);
                        _.Diagram.DiagramData.AddConnection(handlerReference,eventNode);
                    })
                    {
                        Item = item
                    };
                    yield return quickAddAction;
                }
                
            }
        }
    }

    public interface ICreateAssetListener
    {
        void AssetCreated(Type assetType, object asset);
    }
    public static class uFrameECSHelpers
    {
        
    }


}
