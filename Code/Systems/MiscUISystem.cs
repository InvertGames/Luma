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
    
    
    public partial class MiscUISystem : MiscUISystemBase {

        protected override void LoadingScreenIsLoadingChanged(LoadingScreen data, LoadingScreen @group, PropertyChangedEvent<bool> value)
        {
            base.LoadingScreenIsLoadingChanged(data, @group, value);
        //    data.UIContainer.SetActive(value.CurrentValue);
        }

        protected override void LoadingScreenMessageChanged(LoadingScreen data, LoadingScreen @group, PropertyChangedEvent<string> value)
        {
            base.LoadingScreenMessageChanged(data, @group, value);
        //    data.MessageText.text = value.CurrentValue;
        }

        protected override void TaskIndicatorIsRunningChanged(BackgroundTaskIndicator data, BackgroundTaskIndicator @group,
            PropertyChangedEvent<bool> value)
        {
            base.TaskIndicatorIsRunningChanged(data, @group, value);
        //    data.UIContainer.SetActive(value.CurrentValue);
        }

        protected override void TaskIndicatorMessageChanged(BackgroundTaskIndicator data, BackgroundTaskIndicator @group,
            PropertyChangedEvent<string> value)
        {
            base.TaskIndicatorMessageChanged(data, @group, value);
        //    data.MessageText.text = value.CurrentValue;
        }
    }
}
