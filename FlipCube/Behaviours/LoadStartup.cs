using UnityEngine;
using System.Collections;
using Invert.ECS;
using Invert.ECS.Unity;

public class LoadStartup : MonoBehaviour {

        [SerializeField]
        private string systemSceneName = "Startup";

        public string SystemSceneName
        {
            get
            {
                return this.systemSceneName;
            }

            set
            {
                this.systemSceneName = value;
            }
        }

        public void Awake()
        {
            UnityGame game = GameObject.FindObjectOfType<UnityGame>();
            if (game == null)
            {
                Application.LoadLevelAdditive(this.SystemSceneName);
            }
        }
}
