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
    
    
    public partial class LeaderboardListWidgetGroup : ReactiveGroup<LeaderboardListWidget> {
        
        private IEcsComponentManagerOf<LeaderboardListUI> _LeaderboardListUIManager;
        
        private IEcsComponentManagerOf<UIWidget> _UIWidgetManager;
        
        private int lastEntityId;
        
        private LeaderboardListUI LeaderboardListUI;
        
        private UIWidget UIWidget;
        
        public IEcsComponentManagerOf<LeaderboardListUI> LeaderboardListUIManager {
            get {
                return _LeaderboardListUIManager;
            }
            set {
                _LeaderboardListUIManager = value;
            }
        }
        
        public IEcsComponentManagerOf<UIWidget> UIWidgetManager {
            get {
                return _UIWidgetManager;
            }
            set {
                _UIWidgetManager = value;
            }
        }
        
        public override System.Collections.Generic.IEnumerable<UniRx.IObservable<int>> Install(uFrame.ECS.IComponentSystem componentSystem) {
            LeaderboardListUIManager = componentSystem.RegisterComponent<LeaderboardListUI>();
            yield return LeaderboardListUIManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return LeaderboardListUIManager.RemovedObservable.Select(_=>_.EntityId);;
            UIWidgetManager = componentSystem.RegisterComponent<UIWidget>();
            yield return UIWidgetManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return UIWidgetManager.RemovedObservable.Select(_=>_.EntityId);;
        }
        
        public override bool Match(int entityId) {
            lastEntityId = entityId;
            if ((LeaderboardListUI = LeaderboardListUIManager[entityId]) == null) {
                return false;
            }
            if ((UIWidget = UIWidgetManager[entityId]) == null) {
                return false;
            }
            return true;
        }
        
        public override LeaderboardListWidget Select() {
            var item = new LeaderboardListWidget();;
            item.EntityId = lastEntityId;
            item.LeaderboardListUI = LeaderboardListUI;
            item.UIWidget = UIWidget;
            return item;
        }
    }
}
