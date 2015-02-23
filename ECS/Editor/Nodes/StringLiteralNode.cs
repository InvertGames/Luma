namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class StringLiteralNode : StringLiteralNodeBase {
        public override string Literal
        {
            get { return string.Format("\"{0}\"", this.Name); }
        }
    }
    
    public partial interface IStringLiteralConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
