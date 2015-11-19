namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class TeliporterPlateSystem : TeliporterPlateSystemBase {
        /*protected override void TeliporterPlateSystemRollCompleteStandingUpHandler(RollCompleteStandingUp data, PlayerRoller player,
            TeliporterPlate plate)
        {

            var targetPosition = plate.Target.transform.position;
            this.Publish(new MoveRoller()
            {
                Roller = player.Roller.EntityId,
                X = targetPosition.x,
                Y = targetPosition.y,
                Z = targetPosition.z
            });
        }*/

    }
}
