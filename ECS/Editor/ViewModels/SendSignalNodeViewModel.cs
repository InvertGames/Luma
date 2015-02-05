namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class SendSignalNodeViewModel : SendSignalNodeViewModelBase {
        
        public SendSignalNodeViewModel(SendSignalNode graphItemObject, Invert.Core.GraphDesigner.DiagramViewModel diagramViewModel) : 
                base(graphItemObject, diagramViewModel) {
        }

        public override bool IsEditable
        {
            get { return false; }
        }
    }
}
