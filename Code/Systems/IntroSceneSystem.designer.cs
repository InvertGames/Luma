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
    using FlipCube;
    using UniRx;
    
    
    public partial class IntroSceneSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<Intro> _IntroManager;
        
        private IEcsComponentManagerOf<RunningLevel> _RunningLevelManager;
        
        private IEcsComponentManagerOf<LevelScene> _LevelSceneManager;
        
        private IEcsComponentManagerOf<UIScene> _UISceneManager;
        
        private IEcsComponentManagerOf<ZoneData> _ZoneDataManager;
        
        private IEcsComponentManagerOf<LevelData> _LevelDataManager;
        
        public IEcsComponentManagerOf<Intro> IntroManager {
            get {
                return _IntroManager;
            }
            set {
                _IntroManager = value;
            }
        }
        
        public IEcsComponentManagerOf<RunningLevel> RunningLevelManager {
            get {
                return _RunningLevelManager;
            }
            set {
                _RunningLevelManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LevelScene> LevelSceneManager {
            get {
                return _LevelSceneManager;
            }
            set {
                _LevelSceneManager = value;
            }
        }
        
        public IEcsComponentManagerOf<UIScene> UISceneManager {
            get {
                return _UISceneManager;
            }
            set {
                _UISceneManager = value;
            }
        }
        
        public IEcsComponentManagerOf<ZoneData> ZoneDataManager {
            get {
                return _ZoneDataManager;
            }
            set {
                _ZoneDataManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LevelData> LevelDataManager {
            get {
                return _LevelDataManager;
            }
            set {
                _LevelDataManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            IntroManager = ComponentSystem.RegisterComponent<Intro>(2);
            RunningLevelManager = ComponentSystem.RegisterGroup<RunningLevelGroup,RunningLevel>();
            LevelSceneManager = ComponentSystem.RegisterComponent<LevelScene>(40);
            UISceneManager = ComponentSystem.RegisterComponent<UIScene>(41);
            ZoneDataManager = ComponentSystem.RegisterComponent<ZoneData>(1);
            LevelDataManager = ComponentSystem.RegisterComponent<LevelData>(38);
            IntroManager.RemovedObservable.Subscribe(_=>IntroComponentDestroyed(_,_)).DisposeWith(this);
            IntroManager.CreatedObservable.Subscribe(OnPlayIntroFilter).DisposeWith(this);
        }
        
        protected virtual void IntroComponentDestroyed(Intro data, Intro group) {
        }
        
        protected void IntroComponentDestroyedFilter(Intro data) {
            var GroupIntro = IntroManager[data.EntityId];
            if (GroupIntro == null) {
                return;
            }
            if (!GroupIntro.Enabled) {
                return;
            }
            this.IntroComponentDestroyed(data, GroupIntro);
        }
        
        protected virtual void OnPlayIntro(Intro data, Intro group) {
        }
        
        protected void OnPlayIntroFilter(Intro data) {
            var GroupIntro = IntroManager[data.EntityId];
            if (GroupIntro == null) {
                return;
            }
            if (!GroupIntro.Enabled) {
                return;
            }
            this.OnPlayIntro(data, GroupIntro);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("dba54b4f-9c16-498b-ae3c-021f5857b030")]
    public partial class IntroSceneSystem : IntroSceneSystemBase {
        
        private static IntroSceneSystem _Instance;
        
        public IntroSceneSystem() {
            Instance = this;
        }
        
        public static IntroSceneSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
