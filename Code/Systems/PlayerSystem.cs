using UnityEngine;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayerSystem : PlayerSystemBase {
        protected override void ResetPlayerHandler(LevelReset data, PlayerRoller roller)
        {
            //base.ResetPlayerHandler(data, @group);
            this.Publish(new MoveRoller() {Roller = roller.Roller.EntityId});
            //var targetPosition = data.Position;
            //roller.StopAllCoroutines();
            //var startingOffset = cube.IsSingleCube ? 0.5f : 1f;
            //cube.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            //cube.gameObject.SetActive(false);
            //cube.transform.position = new Vector3(targetPosition.x, targetPosition.y + 15f, targetPosition.z);
            //cube.IsRolling = true;
            //cube.transform.positionTo(1f, new Vector3(targetPosition.x, targetPosition.y + startingOffset, targetPosition.z)).setOnCompleteHandler((s) =>
            //{
            //    cube.IsRolling = false;
            //    //            SignalCubeMoved(data);
            //    cube.gameObject.SetActive(true);
            //});

            //cube.RestState = RollerState.StandingUp;
            //cube.GetComponent<Rigidbody>().useGravity = false;
            //UseGravity(cube, false, false);
        }
    }
}
