namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SystemsGraph : SystemsGraphBase {
        public Type NewType(string newType)
        {
            return this.GetType().Assembly.GetType("Invert.ECS.Graphs." + newType);
        }

        public bool IsType(string type, string name)
        {
            return type.StartsWith("Invert.ECS.Graphs." + name) || type.StartsWith(name);
        }
        public override Type FindType(string t)
        {
            if (IsType(t, "ComponentPropertyChildItem"))
            {
                return NewType("PropertiesChildItem");
            }
            if (IsType(t, "EntitiesNode"))
            {
                return NewType("ComponentNode");
            }
            if (IsType(t, "RequiredComponentsChildItem"))
            {
                return NewType("RequiredComponentsReference");
            }
            if (IsType(t, "ComponentCollectionChildItem"))
            {
                return NewType("CollectionsChildItem");
            } 
            if (IsType(t, "EventTypeChildItem"))
            {
                return NewType("EventsChildItem");
            } 
            if (IsType(t, "SystemEventHandlerReference"))
            {
                return NewType("HandlersReference");
            } 
            if (IsType(t, "SystemComponentsReference"))
            {
                return NewType("ComponentsReference");
            } 
            if (IsType(t, "EventHandlerEntityMappingReference"))
            {
                return NewType("RequiredComponentsReference");
            } 
            if (IsType(t, "PropertyMappingsReference"))
            {
                return NewType("PropertyMapsReference");
            }
            if (IsType(t, "EntityComponentsReference"))
            {
                return NewType("ComponentsReference");
            }
            return null;
        }
    }
}
