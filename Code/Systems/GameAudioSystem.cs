namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    using UniRx;
    
    
    public partial class GameAudioSystem {
        protected override void GameAudioSystemPlayAudioFXHandler(PlayAudioFX data)
        {
            base.GameAudioSystemPlayAudioFXHandler(data);
            AudioFXSource.PlayOneShot(data.Clip);
        }
    }
}
