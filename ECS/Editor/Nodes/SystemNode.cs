namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SystemNode : SystemNodeBase {
        private static List<ISystemEventHandler> _systemEvents;

        [ProxySection("Components",SectionVisibility.WhenNodeIsNotFilter)]
        public IEnumerable<ComponentNode> SystemComponents
        {
            get { return this.GetContainingNodes(Graph).OfType<ComponentNode>(); }
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
