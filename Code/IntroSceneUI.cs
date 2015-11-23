using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroSceneUI : MonoBehaviour {


    private GoTweenConfig _fadeInTweenConfig;
    private GoTweenConfig _fadeOutTweenConfig;
    public CanvasGroup Logo;
    public GoTweenConfig FadeInTweenConfig
    {
        get
        {
            return _fadeInTweenConfig ?? (_fadeInTweenConfig = new GoTweenConfig()
              .addTweenProperty(new FloatTweenProperty("alpha", 1)).setDelay(2));
        }
        set { _fadeInTweenConfig = value; }
    }

    public GoTweenConfig FadeOutTweenConfig
    {
        get
        {
            return _fadeOutTweenConfig ?? (_fadeOutTweenConfig = new GoTweenConfig()
              .localPosition(new Vector3(-1000, 0))
              .setEaseType(GoEaseType.ElasticInOut)
              .setDelay(2f));
        }
        set { _fadeOutTweenConfig = value; }
    }


    void Start()
    {
        Logo.alpha = 0;
        Go.to(Logo, 1f, FadeInTweenConfig).setOnCompleteHandler(x =>
        {
            Go.to(Logo.transform, 1f, FadeOutTweenConfig).setOnCompleteHandler(y =>
            {
                Application.LoadLevel("BootScene");
            });
        });
    }

}
