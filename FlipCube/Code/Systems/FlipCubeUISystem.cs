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
    
    public GameObject _ZonePanel;
    public GameObject _LoadingPanel;
    public Text _PercentText;
    public Image _ProgressImage;

    public GameObject panel;
    public Text notificationText;
    public Text zoneLabel;
    public Text levelLabel;
    public Text xpLabel;
    public Text scoreLabel;
    public Button zonesButton;

    public GameObject _HudPanel;
    //public Text text;
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
        panel.SetActive(false);
        _LoadingPanel.SetActive(true);
        zonesButton.onClick.AddListener(() =>
        {
            WindowSystem.SignalShowWindow(Game, new WindowEventData()
            {
                Window = FlipCubeWindow.Zones
            });
        });
    }

    protected override void OnLoadingProgress(LoadingProgressData data)
    {
        base.OnLoadingProgress(data);

        //_LoadingPanel.SetActive(true);
        _ProgressImage.fillAmount = data.Progress;
        _PercentText.text = (data.Progress*100f) + "%";
        
    }

    protected override void OnGameReady(EntityEventData data)
    {
        base.OnGameReady(data);
        if (_LoadingPanel != null)
        {
            _LoadingPanel.SetActive(false);
        }
        
    }

    

    protected override void OnLevelEntered(LevelEventData data)
    {
        base.OnLevelEntered(data);
        _HudPanel.SetActive(true);
        levelLabel.text = data.LevelData.LevelNumber.ToString();
    }

    protected override void OnZoneEntered(ZoneEventData data)
    {
        base.OnZoneEntered(data);
        _HudPanel.SetActive(false);
        zoneLabel.text = data.Zone.ZoneName;
   
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
    public void ZoneClicked()
    {
        _ZonePanel.SetActive(true);
        
    }
}
