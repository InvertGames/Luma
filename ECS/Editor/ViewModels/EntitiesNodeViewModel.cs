namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class EntitiesNodeViewModel : EntitiesNodeViewModelBase {
        
        public EntitiesNodeViewModel(EntitiesNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
}
