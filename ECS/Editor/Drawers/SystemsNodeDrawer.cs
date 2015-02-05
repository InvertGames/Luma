namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class SystemsNodeDrawer : GenericNodeDrawer<SystemsNode,SystemsNodeViewModel> {
        
        public SystemsNodeDrawer(SystemsNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
