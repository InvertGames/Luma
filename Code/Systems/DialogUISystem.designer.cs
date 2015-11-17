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
    using UnityEngine;
    using UnityEngine.UI;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class DialogUISystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<DialogUI> _DialogUIManager;
        
        private IEcsComponentManagerOf<Dialog> _DialogManager;
        
        public IEcsComponentManagerOf<DialogUI> DialogUIManager {
            get {
                return _DialogUIManager;
            }
            set {
                _DialogUIManager = value;
            }
        }
        
        public IEcsComponentManagerOf<Dialog> DialogManager {
            get {
                return _DialogManager;
            }
            set {
                _DialogManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            DialogUIManager = ComponentSystem.RegisterComponent<DialogUI>(16);
            BlackBoardSystem.EnsureBlackBoard<DialogUI>();
            DialogManager = ComponentSystem.RegisterComponent<Dialog>(37);
            DialogManager.CreatedObservable.Subscribe(OnDialogCreatedFilter).DisposeWith(this);
            this.CollectionItemRemoved<DialogUI,FlipCube.Dialog>(Group=>Group.DialogQueue, OnDialogRemovedFromQueueFilter);
            DialogUIManager.CreatedObservable.Subscribe(OnDialogUICreatedFilter).DisposeWith(this);
            this.CollectionItemAdded<DialogUI,FlipCube.Dialog>(Group=>Group.DialogQueue, OnDialogAddedToQueueFilter, false);
        }
        
        protected virtual void OnDialogCreated(Dialog data, Dialog group) {
        }
        
        protected void OnDialogCreatedFilter(Dialog data) {
            var GroupDialog = DialogManager[data.EntityId];
            if (GroupDialog == null) {
                return;
            }
            if (!GroupDialog.Enabled) {
                return;
            }
            this.OnDialogCreated(data, GroupDialog);
        }
        
        protected virtual void OnDialogRemovedFromQueue(DialogUI data, DialogUI group, FlipCube.Dialog item) {
        }
        
        protected void OnDialogRemovedFromQueueFilter(DialogUI data, FlipCube.Dialog item) {
            var GroupDialogUI = DialogUIManager[data.EntityId];
            if (GroupDialogUI == null) {
                return;
            }
            if (!GroupDialogUI.Enabled) {
                return;
            }
            this.OnDialogRemovedFromQueue(data, GroupDialogUI, item);
        }
        
        protected virtual void OnDialogUICreated(DialogUI data, DialogUI group) {
        }
        
        protected void OnDialogUICreatedFilter(DialogUI data) {
            var GroupDialogUI = DialogUIManager[data.EntityId];
            if (GroupDialogUI == null) {
                return;
            }
            if (!GroupDialogUI.Enabled) {
                return;
            }
            this.OnDialogUICreated(data, GroupDialogUI);
        }
        
        protected virtual void OnDialogAddedToQueue(DialogUI data, DialogUI group, FlipCube.Dialog item) {
        }
        
        protected void OnDialogAddedToQueueFilter(DialogUI data, FlipCube.Dialog item) {
            var GroupDialogUI = DialogUIManager[data.EntityId];
            if (GroupDialogUI == null) {
                return;
            }
            if (!GroupDialogUI.Enabled) {
                return;
            }
            this.OnDialogAddedToQueue(data, GroupDialogUI, item);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("b114ea6a-cfa5-4bed-b639-6bc8d82057fb")]
    public partial class DialogUISystem : DialogUISystemBase {
        
        private static DialogUISystem _Instance;
        
        public DialogUISystem() {
            Instance = this;
        }
        
        public static DialogUISystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
