namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlateSystem : PlateSystemBase {
        protected override void PlateSystemOnCollisionEnterHandler(OnCollisionEnterDispatcher data, Plate collider, Player source)
        {
            this.Publish(new PlayerLandedOnPlate()
            {
                Plate = collider.EntityId,
                Player = source.EntityId
            });
            
        }

        protected override void PlateSystemOnCollisionExitHandler(OnCollisionExitDispatcher data, Plate collider, Player source)
        {
            this.Publish(new PlayerLeftPlate()
            {
                Plate = collider.EntityId,
                Player = source.EntityId
            });
        }
    }
}
