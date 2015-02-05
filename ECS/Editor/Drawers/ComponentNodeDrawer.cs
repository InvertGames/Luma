namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ComponentNodeDrawer : GenericNodeDrawer<ComponentNode,ComponentNodeViewModel> {
        
        public ComponentNodeDrawer(ComponentNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
