namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class MultiVariableInputSlot : MultiVariableInputSlotBase {
    }
    
    public partial interface IMultiVariableInputSlot : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
