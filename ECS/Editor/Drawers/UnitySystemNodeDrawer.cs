namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class UnitySystemNodeDrawer : GenericNodeDrawer<UnitySystemNode,UnitySystemNodeViewModel> {
        
        public UnitySystemNodeDrawer(UnitySystemNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
