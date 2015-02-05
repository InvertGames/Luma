namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class ComponentNodeViewModel : ComponentNodeViewModelBase {
        
        public ComponentNodeViewModel(ComponentNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
}
