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
    using uFrame.ECS;
    using uFrame.Kernel;
    
    
    #region 
static
    public class LevelManagementModuleExtensions {
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<Intro> IntroManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Intro>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<ZoneData> ZoneDataManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<ZoneData>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<LevelScene> LevelSceneManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<LevelScene>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.IEcsComponentManagerOf<LevelData> LevelDataManager(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<LevelData>();
        }
        #endregion
        
        #region 
static
        public List<Intro> IntroComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Intro>().Components;
        }
        #endregion
        
        #region 
static
        public List<ZoneData> ZoneDataComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<ZoneData>().Components;
        }
        #endregion
        
        #region 
static
        public List<LevelScene> LevelSceneComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<LevelScene>().Components;
        }
        #endregion
        
        #region 
static
        public List<LevelData> LevelDataComponents(this uFrame.ECS.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<LevelData>().Components;
        }
        #endregion
    }
    #endregion
}
