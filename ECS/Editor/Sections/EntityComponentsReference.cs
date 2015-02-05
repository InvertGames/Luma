namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class EntityComponentsReference : EntityComponentsReferenceBase {
    }
    
    public partial interface IEntityComponents : Invert.Core.GraphDesigner.IDiagramNodeItem, Invert.Core.GraphDesigner.IConnectable {
    }
}
