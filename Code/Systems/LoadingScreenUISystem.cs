using UnityEngine.UI;

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
    
    
    public partial class LoadingScreenUISystem {
        protected override void LoadingScreenMessageChanged(LoadingScreenWidget data, LoadingScreenWidget @group, PropertyChangedEvent<string> value)
        {
            base.LoadingScreenMessageChanged(data, @group, value);
            var messageText = data.LoadingScreenUI.MessageText;
            if(messageText != null) messageText.text = data.LoadingScreenUI.Message;
        }

        protected override void LoadingScreenProgressChanged(LoadingScreenWidget data, LoadingScreenWidget @group, PropertyChangedEvent<float> value)
        {
            base.LoadingScreenProgressChanged(data, @group, value);
            var persentsText = data.LoadingScreenUI.PersentsText;
            var image = data.LoadingScreenUI.FilledProgressBar;
            if (persentsText != null) persentsText.text = string.Format("{0}%", (int)(value.CurrentValue * 100));
            if (image != null) image.fillAmount = value.CurrentValue;
        }
    }
}
