namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class EqualNode : EqualNodeBase {
        protected override void WriteTrueStatements(TemplateContext ctx)
        {
            base.WriteTrueStatements(ctx);
            var actionNode = TrueOutputSlot.OutputTo<ActionNode>();
            if (actionNode != null)
            {
                actionNode.WriteCode(ctx);
            }
        }

        protected override void WriteFalseStatements(TemplateContext ctx)
        {
            base.WriteFalseStatements(ctx);
            var actionNode = FalseOutputSlot.OutputTo<ActionNode>();
            if (actionNode != null)
            {
                actionNode.WriteCode(ctx);
            }
        }
    }
    
    public partial interface IEqualConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
