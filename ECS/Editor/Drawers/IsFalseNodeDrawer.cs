namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class IsFalseNodeDrawer : GenericNodeDrawer<IsFalseNode,IsFalseNodeViewModel> {
        
        public IsFalseNodeDrawer(IsFalseNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
