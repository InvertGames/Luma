namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine.UI;
    using FlipCube;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class DemoPlayerSystem : DemoPlayerSystemBase {
        
        protected override void DemoPlayerSystemGameReadyHandler(uFrame.Kernel.GameReadyEvent data) {
        }
        
        protected override void NotifyLoginHandler(FlipCube.UserLoggedIn data) {
        }
    }
}
