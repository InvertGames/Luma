using UnityEngine;

public class LoadSystemSceneAdditive : MonoBehaviour
{

    [SerializeField]
    private string systemSceneName = "";

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
  
        Application.LoadLevelAdditive(this.SystemSceneName);
        
    }
}