namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using UnityEngine.UI;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class NotificationsUISystem : NotificationsUISystemBase {
        
        protected override void DisableAllNotificationUIHandler(uFrame.Kernel.GameReadyEvent data, NotificationUI group) {
        }
        
        protected override void DisplayNotificationMessageHandler(FlipCube.NotificationMessage data, NotificationUI group) {
        }
    }
}
