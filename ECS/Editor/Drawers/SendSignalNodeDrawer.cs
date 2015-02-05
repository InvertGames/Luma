namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SendSignalNodeDrawer : GenericNodeDrawer<SendSignalNode,SendSignalNodeViewModel> {
        
        public SendSignalNodeDrawer(SendSignalNodeViewModel viewModel) : 
                base(viewModel) {
        }
        
    }
}
