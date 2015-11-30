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
    
    
    public partial class GameUISystem {
        protected override void GameUICreated(GameUIWidget data, GameUIWidget @group)
        {
            base.GameUICreated(data, @group);
        }

        protected override void GameUISystemCloseAllGeneralMenusHandler(CloseAllGeneralMenus data, GameUIWidget @group)
        {
            base.GameUISystemCloseAllGeneralMenusHandler(data, @group);
            if(LevelManagementSystem.Instance.CurrentActiveLevel == null) Show<MainMenuUI>(@group);
            else HideAllGeneralMenus(@group);

        }

        protected override void GameUISystemShowGeneralMenusHandler(ShowGeneralMenu data, GameUIWidget @group)
        {
            base.GameUISystemShowGeneralMenusHandler(data, @group);
            @group.GameUI.State = data.State;
        }

        private void HideAllGeneralMenus(GameUIWidget data)
        {
            foreach (var widget in data.Composite.Widgets)
            {
                widget.IsActive = false;
            }
        }

        protected override void GameUIStateChanged(GameUIWidget data, GameUIWidget @group, PropertyChangedEvent<GeneralGameUIState> value)
        {
            base.GameUIStateChanged(data, @group, value);
            switch (value.CurrentValue)
            {
                case GeneralGameUIState.LeaderBoard:
                    Show<LeaderboardWidget>(data);
                    break;
                case GeneralGameUIState.LevelSelection:
                    Show<LevelSelectionWidget>(data);
                    break;
                case GeneralGameUIState.MainMenu:
                    Show<MainMenuUI>(data);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Show<T>(GameUIWidget data) where T : class, IEcsComponent
        {
            foreach (var widget in data.Composite.Widgets)
            {
                var cWidget = widget.As<T>();
                widget.IsActive = cWidget != null;
            }
        }
    }
}
