using UnityEngine;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class GameUISystem : GameUISystemBase {
        private GameUI _gameUi;


        public GameUI GameUI
        {
            get { return _gameUi ?? (_gameUi = GameUIManager.Components.FirstOrDefault()); }
            set { _gameUi= value; }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameUI.GeneralState = GeneralGameUIState.MainMenu;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                GameUI.GeneralState = GeneralGameUIState.Authentication;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameUI.GeneralState = GeneralGameUIState.None;
            }


        }

        protected override void NewPropertyChangedNode(GameUI data, GameUI @group, PropertyChangedEvent<GeneralGameUIState> value)
        {
            base.NewPropertyChangedNode(data, @group, value);
            data.MainMenuAnimator.SetInteger("State",(int)value.CurrentValue);
        }
    }
}
