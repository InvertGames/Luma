using uFrame.Kernel;
using UnityEngine;

namespace FlipCube {
    public partial class SceneInstance
    {

        public string KernelScene;

        protected override void Start()
        {
            if (!uFrameKernel.IsKernelLoaded)
            {
                SceneDataName = Application.loadedLevelName;
                StartCoroutine(uFrameKernel.InstantiateSceneAsyncAdditively(KernelScene));
            }

            base.Start();
        }
    }
}
