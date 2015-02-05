namespace Invert.ECS.Graphs {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core.GraphDesigner;
    
    
    public class EntitiesNodeDrawer : GenericNodeDrawer<EntitiesNode,EntitiesNodeViewModel> {
        
        public EntitiesNodeDrawer(EntitiesNodeViewModel viewModel) : 
                base(viewModel) {
        }
    }
}
