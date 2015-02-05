namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class UnitySystemNodeViewModel : UnitySystemNodeViewModelBase {
        
        public UnitySystemNodeViewModel(UnitySystemNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }
    }
}
