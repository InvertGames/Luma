namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SingleVariableInputSlot : SingleVariableInputSlotBase {
    }
    
    public partial interface ISingleVariableInputSlot : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
