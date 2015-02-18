namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class StateNodeDrawer : GenericNodeDrawer<StateNode,StateNodeViewModel> {
        
        public StateNodeDrawer(StateNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
