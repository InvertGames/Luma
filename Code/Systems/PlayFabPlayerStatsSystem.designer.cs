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
    using FlipCube;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayFabPlayerStatsSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<IPlayerStat> _PlayerStatManager;
        
        private IEcsComponentManagerOf<Settings> _SettingsManager;
        
        public IEcsComponentManagerOf<IPlayerStat> PlayerStatManager {
            get {
                return _PlayerStatManager;
            }
            set {
                _PlayerStatManager = value;
            }
        }
        
        public IEcsComponentManagerOf<Settings> SettingsManager {
            get {
                return _SettingsManager;
            }
            set {
                _SettingsManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            PlayerStatManager = ComponentSystem.RegisterGroup<PlayerStatGroup,IPlayerStat>();
            SettingsManager = ComponentSystem.RegisterComponent<Settings>(22);
            BlackBoardSystem.EnsureBlackBoard<Settings>();
            this.OnEvent<FlipCube.SaveData>().Subscribe(_=>{ SavePlayerStatsFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.LoadData>().Subscribe(_=>{ LoadPlayerStatsFilter(_); }).DisposeWith(this);
            PlayerStatManager.CreatedObservable.Subscribe(LoadPlayerStatFilter).DisposeWith(this);
        }
        
        protected virtual void SavePlayerStatsHandler(FlipCube.SaveData data) {
        }
        
        protected void SavePlayerStatsFilter(FlipCube.SaveData data) {
            this.SavePlayerStatsHandler(data);
        }
        
        protected virtual void LoadPlayerStatsHandler(FlipCube.LoadData data) {
        }
        
        protected void LoadPlayerStatsFilter(FlipCube.LoadData data) {
            this.LoadPlayerStatsHandler(data);
        }
        
        protected virtual void LoadPlayerStat(IPlayerStat data, IPlayerStat group) {
        }
        
        protected void LoadPlayerStatFilter(IPlayerStat data) {
            var GroupItem = PlayerStatManager[data.EntityId];
            if (GroupItem == null) {
                return;
            }
            if (!GroupItem.Enabled) {
                return;
            }
            this.LoadPlayerStat(data, GroupItem);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("147bb1c5-604c-4c27-985b-3e1a879ee172")]
    public partial class PlayFabPlayerStatsSystem : PlayFabPlayerStatsSystemBase {
        
        private static PlayFabPlayerStatsSystem _Instance;
        
        [UnityEngine.SerializeField()]
        private Dictionary<string,int> _PlayerStats;
        
        public PlayFabPlayerStatsSystem() {
            Instance = this;
        }
        
        public static PlayFabPlayerStatsSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
        
        public Dictionary<string,int> PlayerStats {
            get {
                return _PlayerStats;
            }
            set {
                _PlayerStats = value;
            }
        }
    }
}
