using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Invert.ECS;
using Invert.Json;
using UnityEngine;


public class PlayerDataSystem : PlayerDataSystemBase
{

    private ComponentManager<ISavableComponent> _saveableManager;

    public ComponentManager<ISavableComponent> SaveableManager
    {
        get { return _saveableManager ?? (_saveableManager = new ComponentManager<ISavableComponent>()); }
        set { _saveableManager = value; }
    }

    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e);
        var saveable = e.Data as ISavableComponent;
        if (saveable != null)
        {
            if (!SaveableManager.Components.Contains(saveable))
            SaveableManager.RegisterComponent(saveable);
            LoadComponent(saveable);
        }
    }

    private void LoadComponent(ISavableComponent saveable)
    {
        var str = GetDataByEntity(saveable.EntityId + "_" + saveable.GetType().Name);
        if (str != null)
        {
            DeserializeComponent(JSON.Parse(str), saveable);
            Debug.Log(string.Format("Loaded entity {0} : with {1}", saveable.EntityId, str));
        }
    }

    public void LoadAllComponents()
    {
        foreach (var item in SaveableManager.Components)
        {

            LoadComponent(item);
        }
    }
    public virtual string GetDataByEntity(string entityId)
    {
        return PlayerPrefs.GetString(entityId.ToString(), null);
    }

    public virtual void SetDataByEntity(string entityId, string data)
    {
        PlayerPrefs.SetString(entityId.ToString(), data);
    }

    protected override void ComponentDestroyed(IEvent e)
    {
        base.ComponentDestroyed(e);
        var saveable = e.Data as ISavableComponent;
        if (saveable != null)
        {
           SaveableManager.UnRegisterComponent(saveable);
        }
    }

    protected override void OnSaveGame(SaveGameEventData data)
    {
        base.OnSaveGame(data);
        foreach (var component in SaveableManager.Components.Where(p => p.IsDirty))
        {
            var json = SerializeComponent(component).ToString();
            SetDataByEntity(component.EntityId + "_" + component.GetType().Name, json);
            SignalOnSaveComponent(Game,new SaveComponentData()
            {
                Component = component
            });
            Debug.Log(string.Format("Saved {0} - {1}", component.EntityId, json));
            component.IsDirty = false;
        }
    }

    public JSONClass SerializeComponent(IComponent component)
    {
        var node = new JSONClass();
        foreach (var property in component.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
         
            if (property.CanRead && property.CanWrite)
            {
                if (!property.IsDefined(typeof(SaveableAttribute), true)) continue;

                if (property.PropertyType == typeof(int))
                {
                    if (property.IsDefined(typeof (PlayerStatAttribute), true))
                    {
                        SavePlayerStat(component, property.Name, (int) property.GetValue(component, null));
                        continue;
                    }
                    node.Add(property.Name, new JSONData((int)property.GetValue(component, null)));
                    continue;
                }
                if (property.PropertyType == typeof(bool))
                {
                    node.Add(property.Name, new JSONData((bool)property.GetValue(component, null)));
                    continue;
                }
                if (property.PropertyType == typeof(float))
                {
                    node.Add(property.Name, new JSONData((float)property.GetValue(component, null)));
                    continue;
                }
                if (property.PropertyType == typeof(Vector3))
                {
                    node.Add(property.Name, new JSONData((Vector3)property.GetValue(component, null)));
                    continue;
                }
                if (property.PropertyType == typeof(Vector2))
                {
                    node.Add(property.Name, new JSONData((Vector2)property.GetValue(component, null)));
                    continue;
                }
                if (property.PropertyType == typeof(string))
                {
                    node.Add(property.Name, new JSONData((string)property.GetValue(component, null)));
                    continue;
                }
            }
        }
        return node;
    }

    public void DeserializeComponent(JSONNode node, IComponent component)
    {
        foreach (var property in component.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (property.CanRead && property.CanWrite)
            {
                if (!property.IsDefined(typeof(SaveableAttribute), true)) continue;

                var propertyData = node[property.Name];
             

                if (property.PropertyType == typeof(int))
                {
                    if (property.IsDefined(typeof(PlayerStatAttribute), true))
                    {
                        property.SetValue(component, GetPlayerStat(component, property.Name), null);
                        continue;
                    }
                    if (propertyData == null) continue;
                    property.SetValue(component, propertyData.AsInt, null);
                    continue;
                }
                if (propertyData == null) continue;
                if (property.PropertyType == typeof(bool))
                {
                    property.SetValue(component, propertyData.AsBool, null);
                    continue;
                }
                if (property.PropertyType == typeof(float))
                {
                    property.SetValue(component, propertyData.AsFloat, null);
                    continue;
                }
                if (property.PropertyType == typeof(Vector3))
                {
                    property.SetValue(component, propertyData.AsVector3, null);
                    continue;
                }
                if (property.PropertyType == typeof(Vector2))
                {
                    property.SetValue(component, propertyData.AsVector2, null);
                    continue;
                }
                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(component, propertyData.Value, null);
                    continue;
                }
            }
        }

    }

    protected virtual int GetPlayerStat(IComponent component, string key)
    {
        return PlayerPrefs.GetInt(key,0);
    }
    protected virtual void SavePlayerStat(IComponent component, string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

}