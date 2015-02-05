namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ActionNodeDrawer : GenericNodeDrawer<ActionNode,ActionNodeViewModel> {
        
        public ActionNodeDrawer(ActionNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
