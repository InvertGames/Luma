namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayFabPlayerDataSystem : PlayFabPlayerDataSystemBase {
        
        protected override void LoadCloudDataHandler(FlipCube.LoadData data) {
        }
        
        protected override void SaveCloudDataHandler(FlipCube.SaveData data) {
        }
        
        protected override void LoadCloudDataComponent(ICloudData data, ICloudData group) {
        }
    }
}
