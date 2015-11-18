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
    
    
    public partial class PlayerInputSystem {
        
        protected override void PCPlayerInputSystemUpdateHandler(KeyboardPlayerInput group) {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { this.Publish(new MoveLeft() { Player = group.EntityId }); }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { this.Publish(new MoveRight() { Player = group.EntityId }); }
            if (Input.GetKeyDown(KeyCode.UpArrow)) { this.Publish(new MoveForward() { Player = group.EntityId }); }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { this.Publish(new MoveBackward() {Player = group.EntityId}); }

        }
        
      
    }
}
