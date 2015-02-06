namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SystemNode : SystemNodeBase {
        private static List<ISystemEventHandler> _systemEvents;
        [Invert.Core.GraphDesigner.ReferenceSection("Handlers", SectionVisibility.Always, false, false, typeof(ISystemEventHandler), false, OrderIndex = 0, HasPredefinedOptions = false)]
        public virtual System.Collections.Generic.IEnumerable<SystemEventHandlerReference> Handlers
        {
            get
            {
                return ChildItems.OfType<SystemEventHandlerReference>();
            }
        }
        [ProxySection("Components",SectionVisibility.WhenNodeIsNotFilter)]
        public IEnumerable<ComponentNode> SystemComponents
        {
            get { return this.GetContainingNodesInProject(Graph.Project).OfType<ComponentNode>(); }
        }

        [InspectorProperty]
        public bool UnitySystem
        {
            get { return this["Unity System"]; }
            set { this["Unity System"] = value; }
        }

        public override IEnumerable<ISystemEventHandler> PossibleHandlers
        {
            get { return base.PossibleHandlers; }
        }
    }

}
