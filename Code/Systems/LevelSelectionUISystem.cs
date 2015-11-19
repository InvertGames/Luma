using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Director;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class LevelSelectionUISystem : LevelSelectionUISystemBase {
        private LevelSelectionUI _ui;
        private Animator _uiAnimator;
        private int _contentOutHash;
        private int _contentOnHash;
        private IEcsComponentManagerOf<LevelData> _levelDataManager;

        public LevelSelectionUI UI
        {
            get { return _ui ?? (_ui = BlackBoardSystem.Get<LevelSelectionUI> ()); }
            set { _ui = value; }
        }

        public Animator UIAnimator
        {
            get { return UI != null ? UI.Animator : null; }
        }

        public IEcsComponentManagerOf<LevelData> LevelDataManager
        {
            get { return _levelDataManager ?? (_levelDataManager = ComponentSystem.RegisterComponent<LevelData>()); }
            set { _levelDataManager = value; }
        }

        protected override void SkipChanged(LevelSelectionUI data, LevelSelectionUI group, PropertyChangedEvent<System.Int32> value)
        {
            UIAnimator.SetTrigger("ReloadLevelSelectionGrid");
        }

        protected override void HiddenChanged(LevelSelectionUI data, LevelSelectionUI @group, PropertyChangedEvent<bool> value)
        {
            UIAnimator.SetBool("Hidden",value.CurrentValue);
        }
        
        protected override void LevelIndexChanged(LevelSelectionUIItem data, LevelSelectionUIItem group, PropertyChangedEvent<System.Int32> value)
        {
            var levelData = LevelDataManager.ForEntity(data.LevelIndex + 100) as LevelData;
            if (levelData == null)
            {
                data.gameObject.SetActive(false);
            }
            else
            {
                data.gameObject.SetActive(true);
                data.LevelTitleText.text = "Level " + (levelData.EntityId - 100);
            }

        }

        public int ContentOffHash
        {
            get { return _contentOutHash == 0 ? (_contentOutHash = Animator.StringToHash("Content_OFF")) : _contentOutHash; }
            set { _contentOutHash = value; }
        }
        public int ContentOnHash
        {
            get { return _contentOnHash == 0 ? (_contentOnHash = Animator.StringToHash("Content_ON")) : _contentOnHash; }
            set { _contentOnHash = value; }
        }

        protected override void UpdateLevelSelectionGridHandler(LevelSelectionGridReadyForUpdate data)
        {
            base.UpdateLevelSelectionGridHandler(data);
            Debug.Log("Check");
            if (!BlackBoardSystem.Has<LevelSelectionUI>()) return;
            Debug.Log("Update");

            for (int i = 0; i < UI.UIItems.Count; i++)
            {
                UI.UIItems[i].LevelIndex = UI.Skip + i + 1;
            }
        }


        protected override void OnLevelSelectionUIShownHandler(LevelSelectionUIShown data)
        {
            base.OnLevelSelectionUIShownHandler(data);
            if (!BlackBoardSystem.Has<LevelSelectionUI>()) return;

            UI.Hidden = false;

        }

        protected override void OnLevelSelectionUIHidingHandler(LevelSelectionUIHiding data)
        {
            base.OnLevelSelectionUIHidingHandler(data);
            if (!BlackBoardSystem.Has<LevelSelectionUI>()) return;

            UI.Hidden = true;
        }
    }
}


