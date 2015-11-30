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
    
    
    public partial class MainMenuUISystem {
        private GameUI _gameUi;

        public GameUI GameUI
        {
            get { return _gameUi ?? (_gameUi = BlackBoardSystem.Get<GameUI>()); }
            set { _gameUi = value; }
        }

        protected override void MainMenuWidgetCreated(MainMenuWidget data, MainMenuWidget @group)
        {
            base.MainMenuWidgetCreated(data, @group);

        }
    }
}
