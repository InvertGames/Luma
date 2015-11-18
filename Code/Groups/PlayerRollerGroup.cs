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
    using UniRx;
    using uFrame.Kernel;
    
    
    public partial class PlayerRollerGroup : ReactiveGroup<PlayerRoller> {
        
        private IEcsComponentManagerOf<Roller> _RollerManager;
        
        private IEcsComponentManagerOf<Player> _PlayerManager;
        
        private int lastEntityId;
        
        private Roller Roller;
        
        private Player Player;
        
        public IEcsComponentManagerOf<Roller> RollerManager {
            get {
                return _RollerManager;
            }
            set {
                _RollerManager = value;
            }
        }
        
        public IEcsComponentManagerOf<Player> PlayerManager {
            get {
                return _PlayerManager;
            }
            set {
                _PlayerManager = value;
            }
        }
        
        public override System.Collections.Generic.IEnumerable<UniRx.IObservable<int>> Install(uFrame.ECS.IComponentSystem componentSystem) {
            RollerManager = componentSystem.RegisterComponent<Roller>();
            yield return RollerManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return RollerManager.RemovedObservable.Select(_=>_.EntityId);;
            PlayerManager = componentSystem.RegisterComponent<Player>();
            yield return PlayerManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return PlayerManager.RemovedObservable.Select(_=>_.EntityId);;
        }
        
        public override bool Match(int entityId) {
            lastEntityId = entityId;
            if ((Roller = RollerManager[entityId]) == null) {
                return false;
            }
            if ((Player = PlayerManager[entityId]) == null) {
                return false;
            }
            return true;
        }
        
        public override PlayerRoller Select() {
            var item = new PlayerRoller();;
            item.EntityId = lastEntityId;
            item.Roller = Roller;
            item.Player = Player;
            return item;
        }
    }
}
