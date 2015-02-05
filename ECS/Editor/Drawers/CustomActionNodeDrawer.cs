namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class CustomActionNodeDrawer : GenericNodeDrawer<CustomActionNode,CustomActionNodeViewModel> {
        
        public CustomActionNodeDrawer(CustomActionNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
