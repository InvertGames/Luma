namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class ExpressionNodeDrawer : GenericNodeDrawer<ExpressionNode,ExpressionNodeViewModel> {
        
        public ExpressionNodeDrawer(ExpressionNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
