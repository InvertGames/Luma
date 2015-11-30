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
    
    
    public partial class GameUIWidgetGroup : ReactiveGroup<GameUIWidget> {
        
        private IEcsComponentManagerOf<UIWidget> _UIWidgetManager;
        
        private IEcsComponentManagerOf<GameUI> _GameUIManager;
        
        private IEcsComponentManagerOf<Composite> _CompositeManager;
        
        private int lastEntityId;
        
        private UIWidget UIWidget;
        
        private GameUI GameUI;
        
        private Composite Composite;
        
        public IEcsComponentManagerOf<UIWidget> UIWidgetManager {
            get {
                return _UIWidgetManager;
            }
            set {
                _UIWidgetManager = value;
            }
        }
        
        public IEcsComponentManagerOf<GameUI> GameUIManager {
            get {
                return _GameUIManager;
            }
            set {
                _GameUIManager = value;
            }
        }
        
        public IEcsComponentManagerOf<Composite> CompositeManager {
            get {
                return _CompositeManager;
            }
            set {
                _CompositeManager = value;
            }
        }
        
        public override System.Collections.Generic.IEnumerable<UniRx.IObservable<int>> Install(uFrame.ECS.IComponentSystem componentSystem) {
            UIWidgetManager = componentSystem.RegisterComponent<UIWidget>();
            yield return UIWidgetManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return UIWidgetManager.RemovedObservable.Select(_=>_.EntityId);;
            GameUIManager = componentSystem.RegisterComponent<GameUI>();
            yield return GameUIManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return GameUIManager.RemovedObservable.Select(_=>_.EntityId);;
            CompositeManager = componentSystem.RegisterComponent<Composite>();
            yield return CompositeManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return CompositeManager.RemovedObservable.Select(_=>_.EntityId);;
        }
        
        public override bool Match(int entityId) {
            lastEntityId = entityId;
            if ((UIWidget = UIWidgetManager[entityId]) == null) {
                return false;
            }
            if ((GameUI = GameUIManager[entityId]) == null) {
                return false;
            }
            if ((Composite = CompositeManager[entityId]) == null) {
                return false;
            }
            return true;
        }
        
        public override GameUIWidget Select() {
            var item = new GameUIWidget();;
            item.EntityId = lastEntityId;
            item.UIWidget = UIWidget;
            item.GameUI = GameUI;
            item.Composite = Composite;
            return item;
        }
    }
}
