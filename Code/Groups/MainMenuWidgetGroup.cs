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
    
    
    public partial class MainMenuWidgetGroup : ReactiveGroup<MainMenuWidget> {
        
        private IEcsComponentManagerOf<UIWidget> _UIWidgetManager;
        
        private IEcsComponentManagerOf<MainMenuUI> _MainMenuUIManager;
        
        private int lastEntityId;
        
        private UIWidget UIWidget;
        
        private MainMenuUI MainMenuUI;
        
        public IEcsComponentManagerOf<UIWidget> UIWidgetManager {
            get {
                return _UIWidgetManager;
            }
            set {
                _UIWidgetManager = value;
            }
        }
        
        public IEcsComponentManagerOf<MainMenuUI> MainMenuUIManager {
            get {
                return _MainMenuUIManager;
            }
            set {
                _MainMenuUIManager = value;
            }
        }
        
        public override System.Collections.Generic.IEnumerable<UniRx.IObservable<int>> Install(uFrame.ECS.IComponentSystem componentSystem) {
            UIWidgetManager = componentSystem.RegisterComponent<UIWidget>();
            yield return UIWidgetManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return UIWidgetManager.RemovedObservable.Select(_=>_.EntityId);;
            MainMenuUIManager = componentSystem.RegisterComponent<MainMenuUI>();
            yield return MainMenuUIManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return MainMenuUIManager.RemovedObservable.Select(_=>_.EntityId);;
        }
        
        public override bool Match(int entityId) {
            lastEntityId = entityId;
            if ((UIWidget = UIWidgetManager[entityId]) == null) {
                return false;
            }
            if ((MainMenuUI = MainMenuUIManager[entityId]) == null) {
                return false;
            }
            return true;
        }
        
        public override MainMenuWidget Select() {
            var item = new MainMenuWidget();;
            item.EntityId = lastEntityId;
            item.UIWidget = UIWidget;
            item.MainMenuUI = MainMenuUI;
            return item;
        }
    }
}
