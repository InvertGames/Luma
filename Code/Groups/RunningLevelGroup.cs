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
    using UniRx;
    
    
    public partial class RunningLevelGroup : ReactiveGroup<RunningLevel> {
        
        private IEcsComponentManagerOf<LevelData> _LevelDataManager;
        
        private IEcsComponentManagerOf<SceneInstance> _SceneInstanceManager;
        
        private int lastEntityId;
        
        private LevelData LevelData;
        
        private SceneInstance SceneInstance;
        
        public IEcsComponentManagerOf<LevelData> LevelDataManager {
            get {
                return _LevelDataManager;
            }
            set {
                _LevelDataManager = value;
            }
        }
        
        public IEcsComponentManagerOf<SceneInstance> SceneInstanceManager {
            get {
                return _SceneInstanceManager;
            }
            set {
                _SceneInstanceManager = value;
            }
        }
        
        public override System.Collections.Generic.IEnumerable<UniRx.IObservable<int>> Install(uFrame.ECS.IComponentSystem componentSystem) {
            LevelDataManager = componentSystem.RegisterComponent<LevelData>();
            yield return LevelDataManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return LevelDataManager.RemovedObservable.Select(_=>_.EntityId);;
            SceneInstanceManager = componentSystem.RegisterComponent<SceneInstance>();
            yield return SceneInstanceManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return SceneInstanceManager.RemovedObservable.Select(_=>_.EntityId);;
        }
        
        public override bool Match(int entityId) {
            lastEntityId = entityId;
            if ((LevelData = LevelDataManager[entityId]) == null) {
                return false;
            }
            if ((SceneInstance = SceneInstanceManager[entityId]) == null) {
                return false;
            }
            return true;
        }
        
        public override RunningLevel Select() {
            var item = new RunningLevel();;
            item.EntityId = lastEntityId;
            item.LevelData = LevelData;
            item.SceneInstance = SceneInstance;
            return item;
        }
    }
}
