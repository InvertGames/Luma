using UnityEngine;

namespace FlipCube {
    using FlipCube;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    using UniRx;
    
    
    public partial class WinPlateSystem {
        
        protected override void WinPlateRollCompleteStandingUpHandler(FlipCube.RollCompleteStandingUp data, WinPlate plate, Player player) {
            this.Publish(new LevelComplete()
            {
                
            });
            plate.GetComponent<Rigidbody>().useGravity = true;
            plate.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
