// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SystemsNodeBase : Invert.Core.GraphDesigner.GenericNode {
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
    }
    
    public partial interface ISystemsConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class SystemNodeBase : Invert.Core.GraphDesigner.GenericNode, Invert.Core.GraphDesigner.IClassTypeNode {
        
        public virtual string ClassName {
            get {
                return this.Name;
            }
        }
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
        
        public virtual System.Collections.Generic.IEnumerable<IHandlersConnectable> PossibleHandlers {
            get {
                return this.Project.AllGraphItems.OfType<IHandlersConnectable>();
            }
        }
        
        public virtual System.Collections.Generic.IEnumerable<IComponentsConnectable> PossibleComponents {
            get {
                return this.Project.AllGraphItems.OfType<IComponentsConnectable>();
            }
        }
        
        [Invert.Core.GraphDesigner.Section("Events", SectionVisibility.Always, OrderIndex=2)]
        public virtual System.Collections.Generic.IEnumerable<EventsChildItem> Events {
            get {
                return ChildItems.OfType<EventsChildItem>();
            }
        }
        
        [Invert.Core.GraphDesigner.ReferenceSection("Handlers", SectionVisibility.Always, false, false, typeof(IHandlersConnectable), false, OrderIndex=0, HasPredefinedOptions=false)]
        public virtual System.Collections.Generic.IEnumerable<HandlersReference> Handlers {
            get {
                return ChildItems.OfType<HandlersReference>();
            }
        }
        
        [Invert.Core.GraphDesigner.ReferenceSection("Components", SectionVisibility.Always, false, false, typeof(IComponentsConnectable), false, OrderIndex=1, HasPredefinedOptions=false)]
        public virtual System.Collections.Generic.IEnumerable<ComponentsReference> Components {
            get {
                return ChildItems.OfType<ComponentsReference>();
            }
        }
    }
    
    public partial interface ISystemConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class ComponentNodeBase : Invert.Core.GraphDesigner.GenericNode, Invert.Core.GraphDesigner.IClassTypeNode, IComponentsConnectable {
        
        public virtual string ClassName {
            get {
                return this.Name;
            }
        }
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
        
        [Invert.Core.GraphDesigner.Section("Properties", SectionVisibility.Always, OrderIndex=0)]
        public virtual System.Collections.Generic.IEnumerable<PropertiesChildItem> Properties {
            get {
                return ChildItems.OfType<PropertiesChildItem>();
            }
        }
        
        [Invert.Core.GraphDesigner.Section("Collections", SectionVisibility.Always, OrderIndex=0)]
        public virtual System.Collections.Generic.IEnumerable<CollectionsChildItem> Collections {
            get {
                return ChildItems.OfType<CollectionsChildItem>();
            }
        }
    }
    
    public partial interface IComponentConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class EventNodeBase : Invert.Core.GraphDesigner.GenericNode, Invert.Core.GraphDesigner.IClassTypeNode {
        
        public virtual string ClassName {
            get {
                return this.Name;
            }
        }
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
        
        [Invert.Core.GraphDesigner.Section("Properties", SectionVisibility.Always, OrderIndex=0)]
        public virtual System.Collections.Generic.IEnumerable<PropertiesChildItem> Properties {
            get {
                return ChildItems.OfType<PropertiesChildItem>();
            }
        }
        
        [Invert.Core.GraphDesigner.Section("Collections", SectionVisibility.Always, OrderIndex=0)]
        public virtual System.Collections.Generic.IEnumerable<CollectionsChildItem> Collections {
            get {
                return ChildItems.OfType<CollectionsChildItem>();
            }
        }
    }
    
    public partial interface IEventConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class EventHandlerNodeBase : ActionNode {
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
        
        public virtual System.Collections.Generic.IEnumerable<IRequiredComponentsConnectable> PossibleRequiredComponents {
            get {
                return this.Project.AllGraphItems.OfType<IRequiredComponentsConnectable>();
            }
        }
        
        [Invert.Core.GraphDesigner.ReferenceSection("Required Components", SectionVisibility.Always, false, false, typeof(IRequiredComponentsConnectable), false, OrderIndex=0, HasPredefinedOptions=false)]
        public virtual System.Collections.Generic.IEnumerable<RequiredComponentsReference> RequiredComponents {
            get {
                return ChildItems.OfType<RequiredComponentsReference>();
            }
        }
    }
    
    public partial interface IEventHandlerConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class ActionNodeBase : Invert.Core.GraphDesigner.GenericNode, IActionConnectable {
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
    }
    
    public partial interface IActionConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class SimpleClassNodeBase : Invert.Core.GraphDesigner.GenericNode {
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
        
        [Invert.Core.GraphDesigner.Section("Properties", SectionVisibility.Always, OrderIndex=0)]
        public virtual System.Collections.Generic.IEnumerable<PropertiesChildItem> Properties {
            get {
                return ChildItems.OfType<PropertiesChildItem>();
            }
        }
        
        [Invert.Core.GraphDesigner.Section("Collections", SectionVisibility.Always, OrderIndex=0)]
        public virtual System.Collections.Generic.IEnumerable<CollectionsChildItem> Collections {
            get {
                return ChildItems.OfType<CollectionsChildItem>();
            }
        }
    }
    
    public partial interface ISimpleClassConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class SendSignalNodeBase : ActionNode {
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
        
        public virtual System.Collections.Generic.IEnumerable<IPropertyMapsConnectable> PossiblePropertyMaps {
            get {
                return this.Project.AllGraphItems.OfType<IPropertyMapsConnectable>();
            }
        }
        
        [Invert.Core.GraphDesigner.ReferenceSection("Property Maps", SectionVisibility.Always, false, false, typeof(IPropertyMapsConnectable), false, OrderIndex=0, HasPredefinedOptions=false)]
        public virtual System.Collections.Generic.IEnumerable<PropertyMapsReference> PropertyMaps {
            get {
                return ChildItems.OfType<PropertyMapsReference>();
            }
        }
    }
    
    public partial interface ISendSignalConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
    
    public class ConditionNodeBase : ActionNode {
        
        public override bool AllowMultipleInputs {
            get {
                return true;
            }
        }
        
        public override bool AllowMultipleOutputs {
            get {
                return true;
            }
        }
    }
    
    public partial interface IConditionConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
