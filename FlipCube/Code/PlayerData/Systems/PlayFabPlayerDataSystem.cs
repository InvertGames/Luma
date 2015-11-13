using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabPlayerDataSystem : PlayerDataSystem
{
    public string _Username = "mosborne2";
    public string _Password = "micah123";
    public string _TitleId = "F3F5";

    public Dictionary<string, int> Stats { get; set; }
    public Dictionary<string, UserDataRecord> Data { get; set; }
    public bool IsLoggedIn { get; set; }
    public bool IsError { get; set; }

    public override void Initialize(IGame game)
    {
        base.Initialize(game);
        PlayFabSettings.UseDevelopmentEnvironment = false;
        PlayFabSettings.TitleId = "F3F5";
        PlayFabSettings.GlobalErrorHandler = e =>
        {
            NotificationSystem.SignalDisplay(Game, new NotificationData()
            {
                Message = "Got an error: " + e.ErrorMessage
            });
            Debug.Log("Got an error: " + e.ErrorMessage);
        };
    }

    public override IEnumerator Load()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _Username,
            Password = _Password,
            TitleId = _TitleId
        }, r =>
        {
            GetUserDataRequest request = new GetUserDataRequest()
            {
                //Keys = SaveableManager.Components.Select(p => p.EntityId.ToString()).ToList()
            };
            PlayFabClientAPI.GetUserData(request, result =>
            {
                Data = result.Data;
                
                PlayFabClientAPI.GetUserStatistics(new GetUserStatisticsRequest()
                {
                   
                }, _ =>
                {

                    Stats = _.UserStatistics;
                    LoadAllComponents();
                    foreach (var item in Stats)
                    {
                        Debug.Log(string.Format("{0} state was loaded: {1}", item.Key, item.Value));
                    }
                    IsLoggedIn = true;
                    Debug.Log("Data Loaded");
                }, _ =>
                {
                    IsError = true;
                    Debug.Log(_.ErrorMessage);
                });

            
                //SignalLoadData(Game, new EntityEventData());
            }, e =>
            {
                IsError = true;
                Debug.Log(e.ErrorMessage);
            });
        }, null);

        // Wait for login or error
        while (!IsLoggedIn && !IsError)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

   
    public override string GetDataByEntity(string entityId)
    {
        if (Data == null) return null;

        UserDataRecord entityData;
        if (Data.TryGetValue(entityId.ToString(), out entityData))
        {
            return entityData.Value;
        }
        return null;
    }

    protected override void OnSaveGame(SaveGameEventData saveGameEventData)
    {
        UpdateUserDataRequest request = new UpdateUserDataRequest();
        request.Data = new Dictionary<string, string>();
        foreach (var component in SaveableManager.Components.Where(p => p.IsDirty))
        {
            var json = SerializeComponent(component).ToString();
            var key = component.EntityId + "_" + component.GetType().Name;
            request.Data.Add(key, json);
            if (Data != null)
            {
                if (Data.ContainsKey(key))
                {
                    Data.Remove(key);
                }

                Data.Add(key, new UserDataRecord()
                {
                    Value = json
                });
            }
            component.IsDirty = false;
        }
        PlayFabClientAPI.UpdateUserData(request, (r) =>
        {
            Debug.Log(string.Format("Saved data"));
        }, null);
        UpdateUserStatisticsRequest statsRequest = new UpdateUserStatisticsRequest {UserStatistics = Stats};
        PlayFabClientAPI.UpdateUserStatistics(statsRequest, _=>{},null);
    }

    protected override int GetPlayerStat(IComponent component, string key)
    {
        int value;
        if (Stats.TryGetValue(key, out value))
        {
            return value;
        }
        return 0;
    }

    protected override void SavePlayerStat(IComponent component, string key, int value)
    {
        base.SavePlayerStat(component, key, value);
        if (Stats.ContainsKey(key))
        {
            Stats[key] = value;
        }
        else
        {
            Stats.Add(key,value);
        }
    }


}