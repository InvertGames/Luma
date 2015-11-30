namespace FlipCube {
    using FlipCube;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public partial class LevelSelectionUISystem {
        private IEcsComponentManagerOf<LevelData> _levelDataManager;


        public IEcsComponentManagerOf<LevelData> LevelDataManager
        {
            get { return _levelDataManager ?? (_levelDataManager = LevelManagementSystem.Instance.LevelDataManager); }
            set { _levelDataManager = value; }
        }

        protected override void LevelSelectionWidgetCreated(LevelSelectionWidget data, LevelSelectionWidget @group)
        {
            base.LevelSelectionWidgetCreated(data, @group);
            data.LevelSelectionUI.NextButton.OnClickAsObservable().Subscribe(_ => LevelSelectionNextButtonPressed(data));
            data.LevelSelectionUI.BackButton.OnClickAsObservable().Subscribe(_ => LevelSelectionBackButtonPressed(data));
        }


        private void LevelSelectionBackButtonPressed(LevelSelectionWidget data)
        {
            var selectionGrid =
      data.Composite.Widgets.Select(s => LevelGridWidgetManager.ForEntity(s.EntityId) as LevelGridWidget).FirstOrDefault(w => w != null);
            if (selectionGrid != null) MoveSelectionGrid(selectionGrid, - 10);
        }

        private void LevelSelectionNextButtonPressed(LevelSelectionWidget data)
        {
            var selectionGrid =
                data.Composite.Widgets.Select(s => LevelGridWidgetManager.ForEntity(s.EntityId) as LevelGridWidget).FirstOrDefault(w=>w != null);
            if (selectionGrid != null) MoveSelectionGrid(selectionGrid, + 10);
        }

        private void MoveSelectionGrid(LevelGridWidget selectionGrid, int offset)
        {
            var levels = LevelDataManager.Components.ToArray();
            var newSkip = selectionGrid.LevelGridUI.Skip + offset;
            if (newSkip > levels.Length || newSkip < 0) return;
            selectionGrid.LevelGridUI.Skip = newSkip;
        }

        protected override void LevelGridItemBoundLevelChanged(LevelGridItemUI data, LevelGridItemUI @group, PropertyChangedEvent<int> value)
        {
            base.LevelGridItemBoundLevelChanged(data, @group, value);
            var level = LevelDataManager.ForEntity(data.BoundLevel) as LevelData;
            if (level != null)
            {
                data.gameObject.SetActive(true);
                data.LevelNameText.text = (data.BoundLevel - 100) + ""; //level.name;
            }
            else
            {
                data.gameObject.SetActive(false);
            }
        }

        protected override void LevelDataCreated(LevelData data, LevelData @group)
        {
            base.LevelDataCreated(data, @group);
            foreach (var uis in LevelGridWidgetManager.Components)
            {
                uis.LevelGridUI.RequiresUpdate = true;
            }
        }

        protected override void LevelGridRequireUpdateChanged(LevelGridWidget data, LevelGridWidget @group, PropertyChangedEvent<bool> value)
        {
            base.LevelGridRequireUpdateChanged(data, @group, value);
            if(value.CurrentValue && value.CurrentValue != value.PreviousValue)
            data.Animated.Animator.SetTrigger("UpdateRequired");
        }

        protected override void LevelSelectionSkipChanged(LevelGridWidget data, LevelGridWidget @group, PropertyChangedEvent<int> value)
        {
            data.LevelGridUI.RequiresUpdate = true;
        }

        protected override void OnLevelGridTrySelectLevelHandler(LevelGridTrySelectLevel data, LevelGridItemUI source)
        {
            base.OnLevelGridTrySelectLevelHandler(data, source);
            var level = LevelDataManager.ForEntity(source.BoundLevel) as LevelData;
            if (level != null)
            {
                this.Publish(new LoadLevel()
                {
                    Source = level.EntityId
                });
            }
            //TODO : Publish Load Level Event
        }

        protected override void LevelSelectionStateChanged(LevelSelectionWidget data, LevelSelectionWidget @group, PropertyChangedEvent<WidgetState> value)
        {
            base.LevelSelectionStateChanged(data, @group, value);
            if(value.CurrentValue == WidgetState.Shown)
            foreach (var uiWidget in data.Composite.Widgets)
            {
                uiWidget.IsActive = true;
            }
        }


        protected override void LevelGridItemCreated(LevelGridItemUI data, LevelGridItemUI @group)
        {
            base.LevelGridItemCreated(data, @group);
            data.SelectButton.OnClickAsObservable().Subscribe(_ => Publish(new LevelGridTrySelectLevel()
            {
                Source = data.EntityId
            }));
        }

        protected override void LevelGridWidgetStateChanged(LevelGridWidget data, LevelGridWidget @group, PropertyChangedEvent<WidgetState> value)
        {
            base.LevelGridWidgetStateChanged(data, @group, value);
            if (value.CurrentValue == WidgetState.Showing && data.LevelGridUI.RequiresUpdate)
            {
                data.LevelGridUI.RequiresUpdate = false;

                var items = data.LevelGridUI.LevelGridItems.ToArray();
                for (int i = 0; i < items.Length; i++)
                {
                    items[i].BoundLevel = 101 + data.LevelGridUI.Skip + i;
                }
            } 
        }
    }
}
