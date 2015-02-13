using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


// Base class initializes the event listeners.
public class FlipCubeNotifications : FlipCubeNotificationsBase {
    
    public override void Initialize(IGame game) {
        base.Initialize(game);
    }
    
    protected override void Notify(PlateCubeCollsion data, NotifyOnEnter plateid) {
        base.Notify(data, plateid);
        NotificationSystem.SignalDisplay(Game,new NotificationData()
        {
            Message = plateid.Message
        });
    }
}
