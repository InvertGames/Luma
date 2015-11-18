using UnityEngine;

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
            get { return _uiAnimator ?? (_uiAnimator = UI.Animator); }
            set { _uiAnimator = value; }
        }

        public IEcsComponentManagerOf<LevelData> LevelDataManager
        {
            get { return _levelDataManager ?? (_levelDataManager = ComponentSystem.RegisterComponent<LevelData>()); }
            set { _levelDataManager = value; }
        }

        protected override void SkipChanged(LevelSelectionUI data, LevelSelectionUI group, PropertyChangedEvent<System.Int32> value)
        {
            StartCoroutine(AnimatedUIUpdate());
        }
        
        protected override void LimitChanged(LevelSelectionUI data, LevelSelectionUI group, PropertyChangedEvent<System.Int32> value) {
            StartCoroutine(AnimatedUIUpdate());
        }

        protected override void PageChanged(LevelSelectionUI data, LevelSelectionUI group, PropertyChangedEvent<System.Int32> value) {
            StartCoroutine(AnimatedUIUpdate());
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

        protected IEnumerator AnimatedUIUpdate()
        {
            UIAnimator.SetBool("Hidden",true);  
            while (UIAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash != ContentOffHash) yield return null;



            for (int i = 0; i < UI.UIItems.Count; i++)
            {
                UI.UIItems[i].LevelIndex = UI.Skip + i + 1;
            }

            UIAnimator.SetBool("Hidden", false);
            yield break;
        }



    }
}
