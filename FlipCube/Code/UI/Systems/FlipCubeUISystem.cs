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
    public Slider xpSlider;
    public Text rankLabel;
    public Text usernameLabel;
    public Text levelProgressLabel;
    public Slider levelProgressSlider;
    public Text levelTimeLabel;


    public Text movesLabel;
    public Button zonesButton;

    public GameObject _HudPanel;
    //public Text text;
    public override void Initialize(IGame game) {
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
        _PercentText.text = (Mathf.RoundToInt(data.Progress*100f)) + "%";
    }

    public override void Update()
    {
        base.Update();
        if (PlayerManager == null) return;

        foreach (var player in PlayerManager.Components)
        {
            if (player.EntityId != 1) continue;
            usernameLabel.text = player.Name ?? "Unknown User";
            xpLabel.text = player.XP.ToString();
            xpSlider.value = player.XP;
            rankLabel.text = player.Rank.ToString();

            foreach (var zone in ZoneManager.Components)
            {
                if (zone.EntityId == player.CurrentZoneId)
                {
                    zoneLabel.text = zone.ZoneName;
                    
                    break;
                }
            }
            foreach (var level in LevelManager.Components)
            {
                if (level.EntityId == player.CurrentLevelId)
                {
                    levelLabel.text = level.LevelNumber.ToString();
                    levelProgressSlider.maxValue = level.MinimumMoves * 4;
                    levelProgressSlider.value = Math.Max(0f, levelProgressSlider.maxValue - (level.MovesTaken));
                    levelProgressLabel.text = level.CurrentStatus.ToString();
                    var time = level.CurrentTime;
                    levelTimeLabel.text = string.Format("{0}:{1}:{2}", time.Minutes, time.Seconds, time.Milliseconds);
                    break;
                }
            }

            break;
        }

        if (CurrentLevel != null)
        {
            movesLabel.text = CurrentLevel.MovesTaken.ToString();

        }
        
    }

    protected override void OnXpChanged(PlayerExperienceData data, Player player)
    {
        base.OnXpChanged(data, player);
        if (xpLabel != null)
            xpLabel.text = player.XP.ToString();
    }

    protected override void OnGameReady(EntityEventData data)
    {
        base.OnGameReady(data);
        if (_LoadingPanel != null)
        {
            _LoadingPanel.SetActive(false);
        }
        
    }

    //protected override void OnGameReady(GameReadyData data)
    //{
    //    base.OnGameReady(data);
 
    //}

    

    protected override void OnLevelEntered(LevelEventData data)
    {
        base.OnLevelEntered(data);
        CurrentLevel = data.LevelData;
        _HudPanel.SetActive(true);
        levelLabel.text = data.LevelData.LevelNumber.ToString();
    }

    public Level CurrentLevel { get; set; }

    protected override void OnZoneEntered(ZoneEventData data)
    {
        base.OnZoneEntered(data);
        _HudPanel.SetActive(false);
        zoneLabel.text = data.Zone.ZoneName;
        

        var nextZone = ZoneManager.Components.FirstOrDefault(p => p.Index == data.Zone.Index + 1);
        if (nextZone != null)
        {
            xpSlider.maxValue = nextZone.RequiredXp;
        }
        else
        {
            //xpSlider.maxValue = 
        }

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
