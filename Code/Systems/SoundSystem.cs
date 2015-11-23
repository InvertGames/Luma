namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class SoundSystem : SoundSystemBase {
        public FlipCubeSounds Sounds
        {
            get { return this.BlackBoardSystem.Get<FlipCubeSounds>(); }
        }

        protected override void SoundSystemLevelCompleteHandler(LevelComplete data)
        {
            base.SoundSystemLevelCompleteHandler(data);
            if (Sounds != null && Sounds.LevelCompleteSound != null)
                Sounds.LevelCompleteSound.Play();
        }

        protected override void SoundSystemLevelFailedHandler(LevelFailed data)
        {
            base.SoundSystemLevelFailedHandler(data);
            if (Sounds != null && Sounds.LevelFailedSound != null)
                Sounds.LevelFailedSound.Play();
        }

        protected override void SoundSystemLevelResetHandler(LevelReset data)
        {
            base.SoundSystemLevelResetHandler(data);
            if (Sounds != null && Sounds.LevelResetSound != null)
                Sounds.LevelResetSound.Play();
        }

        protected override void PlayRollCompleteSoundHandler(RollComplete data, Roller player)
        {
            base.PlayRollCompleteSoundHandler(data, player);
            if (Sounds != null && Sounds.RollCompleteSound != null)
                Sounds.RollCompleteSound.Play();
        }

        protected override void SoundSystemRollStartHandler(RollStart data, Roller player)
        {
            base.SoundSystemRollStartHandler(data, player);
            if (Sounds != null && Sounds.RollStartSound != null)
                Sounds.RollStartSound.Play();
        }

        protected override void SoundSystemMoveBackwardHandler(MoveBackward data, Roller player)
        {
            base.SoundSystemMoveBackwardHandler(data, player);
            if (Sounds != null && Sounds.MoveSound != null)
            {
                Sounds.MoveSound.Play();
            }
        }

        protected override void SoundSystemMoveForwardHandler(MoveForward data, Roller player)
        {
            base.SoundSystemMoveForwardHandler(data, player);
            if (Sounds != null && Sounds.MoveSound != null)
            {
                Sounds.MoveSound.Play();
            }
        }

        protected override void SoundSystemMoveLeftHandler(MoveLeft data, Roller player)
        {
            base.SoundSystemMoveLeftHandler(data, player);
            if (Sounds != null && Sounds.MoveSound != null)
            {
                Sounds.MoveSound.Play();
            }
        }

        protected override void SoundSystemMoveRightHandler(MoveRight data, Roller player)
        {
            base.SoundSystemMoveRightHandler(data, player);
            if (Sounds != null && Sounds.MoveSound != null)
            {
                Sounds.MoveSound.Play();
            }

        }
    }
}
