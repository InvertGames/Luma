namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class EventNode : EventNodeBase, IClassTypeNode,IDesignerType {
        public string ClassName
        {
            get { return this.Name; }
        }
    }
}
