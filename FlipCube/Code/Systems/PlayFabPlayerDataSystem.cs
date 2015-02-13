using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabPlayerDataSystem : PlayerDataSystem
{
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


    public bool IsLoggedIn { get; set; }
    public bool IsError { get; set; }

    public override IEnumerator Load()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = "mosborne2",
            Password = "micah123",
            TitleId = "F3F5"
        }, r =>
        {
            GetUserDataRequest request = new GetUserDataRequest()
            {
                //Keys = SaveableManager.Components.Select(p => p.EntityId.ToString()).ToList()
            };

          
                PlayFabClientAPI.GetUserData(request, result =>
                {
                    Data = result.Data;
                    LoadAllComponents();
                    IsLoggedIn = true;
                    Debug.Log("Data Loaded");
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

    protected override void OnSaveGame(EntityEventData data)
    {
        UpdateUserDataRequest request = new UpdateUserDataRequest();
        request.Data = new Dictionary<string, string>();
        foreach (var component in SaveableManager.Components.Where(p => p.IsDirty))
        {
            request.Data.Add(component.EntityId + "_" + component.GetType().Name, SerializeComponent(component).ToString());
            component.IsDirty = false;
        }
        PlayFabClientAPI.UpdateUserData(request, (r) =>
        {
            Debug.Log(string.Format("Saved data"));
        }, null);
    }

    public Dictionary<string, UserDataRecord> Data { get; set; }

    protected override void OnLoggedIn(EntityEventData data)
    {
        base.OnLoggedIn(data);

    }


}