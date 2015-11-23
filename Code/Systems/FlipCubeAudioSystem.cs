namespace FlipCube {
    using FlipCube;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    
    
    public partial class FlipCubeAudioSystem
    {

        private int cCounter = 1;
        private int oCounter = 1;

        protected override void NewPropertyChangedNode(UIWidget data, UIWidget @group, PropertyChangedEvent<WidgetState> value)
        {
            base.NewPropertyChangedNode(data, @group, value);

            //
            // YEAH YEAH, I KNOW IT IS UGLY, JUST CLOSE THIS FILE. I'LL FIX IT LATER
            //

            if (data.State == WidgetState.Showing)
            {
                switch (cCounter++ % 3)
                {
                    case 0:
                        PlayClip(WidgetOpen1Clip);
                        break;
                    case 1:
                        PlayClip(WidgetOpen1Clip);
                        break;
                    case 2:
                        PlayClip(WidgetOpen1Clip);
                        break;
                }
            }

            if (data.State == WidgetState.Hiding)
            {
                switch (oCounter++ % 3)
                {
                    case 0:
                        PlayClip(WidgetClose1Clip);
                        break;
                    case 1:
                        PlayClip(WidgetClose1Clip);
                        break;
                    case 2:
                        PlayClip(WidgetClose1Clip);
                        break;
                }
            }
        }

        private void PlayClip(AudioClip widgetOpen1Clip)
        {
            this.Publish(new PlayAudioFX()
            {
                Clip = widgetOpen1Clip
            });

        }
    }
}
