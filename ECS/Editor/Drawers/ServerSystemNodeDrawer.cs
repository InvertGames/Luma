namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ServerSystemNodeDrawer : GenericNodeDrawer<ServerSystemNode,ServerSystemNodeViewModel> {
        
        public ServerSystemNodeDrawer(ServerSystemNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
