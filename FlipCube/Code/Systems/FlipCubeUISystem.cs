using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;
using UnityEngine.UI;

// Base class initializes the event listeners.
public class FlipCubeUISystem : FlipCubeUISystemBase
{
    public GameObject panel;
    public Text notificationText;

    //public Text text;
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
        panel.SetActive(false);
    }
    
    protected override void ShowNotification(NotificationData data) {
        base.ShowNotification(data);
        panel.SetActive(true);
        notificationText.text = data.Message;
        StartCoroutine(Hide());
    }

    public IEnumerator Hide()
    {
        yield return new WaitForSeconds(5f);
        panel.SetActive(false);
    }
}
