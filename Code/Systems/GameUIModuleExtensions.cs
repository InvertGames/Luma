// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.ECS;
    
    
    #region 
static
    public class GameUIModuleExtensions {
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<GameUI> GameUIManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<GameUI>();
        }
        #endregion
        
        #region 
static
        public List<GameUI> GameUIComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<GameUI>().Components;
        }
        #endregion
    }
    #endregion
}
