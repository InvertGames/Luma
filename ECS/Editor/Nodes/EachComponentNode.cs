namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class EachComponentNode : EachComponentNodeBase {
        public override IEnumerable<IContextVariable> ContextVariables
        {
            get { yield return new ContextVariable("item")
            {
                SourceVariable = ComponentInputSlot.InputFrom<ComponentNode>()
            };}
        }

        public override void WriteCode(TemplateContext ctx)
        {
            ctx._("foreach (var item in {0}Manager) {{",ComponentInputSlot.InputFrom<ComponentNode>().Name);
            base.WriteCode(ctx);
            ctx._("}}");
        }
    }
    
    public partial interface IEachComponentConnectable : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
