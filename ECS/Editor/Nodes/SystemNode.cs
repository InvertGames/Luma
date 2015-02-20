namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SystemNode : SystemNodeBase {
        private static List<ISystemEventHandler> _systemEvents;
        [Invert.Core.GraphDesigner.ReferenceSection("Handlers", SectionVisibility.WhenNodeIsFilter, false, false, typeof(ISystemEventHandler), false, OrderIndex = 0, HasPredefinedOptions = false)]
        public override System.Collections.Generic.IEnumerable<HandlersReference> Handlers
        {
            get
            {
                return ChildItems.OfType<HandlersReference>();
            }
        }


        [ProxySection("Component Dependencies", SectionVisibility.WhenNodeIsNotFilter, OrderIndex = 5)]
        public IEnumerable<ComponentNode> SystemComponents
        {
            get { return this.GetContainingNodesInProject(Graph.Project).OfType<ComponentNode>(); }
        }

        [Invert.Core.GraphDesigner.ReferenceSection("Components", SectionVisibility.Always, false, false, typeof(ISystemComponents), false, OrderIndex = 0, HasPredefinedOptions = false)]
        public override System.Collections.Generic.IEnumerable<ComponentsReference> Components
        {
            get
            {
                return ChildItems.OfType<ComponentsReference>();
            }
        }

        public override IEnumerable<IHandlersConnectable> PossibleHandlers
        {
            get { return base.PossibleHandlers; }
        }
    }

}
