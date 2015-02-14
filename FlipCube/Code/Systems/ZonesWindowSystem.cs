using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;
using UnityEngine.UI;


public class ZonesWindowSystem : ZonesWindowSystemBase
{

    public VerticalLayoutGroup _EntriesList;
    public GameObject _ZoneEntryPrefab;


    protected override void Loaded(IEvent e)
    {
        base.Loaded(e);

        for (var i = 0; i < _EntriesList.transform.childCount; i++)
        {
            var item = _EntriesList.transform.GetChild(i).gameObject;
            DestroyImmediate(item);
        }
        foreach (var item in ZoneManager.Components)
        {
            var zoneEntry = Instantiate(_ZoneEntryPrefab) as GameObject;
            zoneEntry.transform.parent = _EntriesList.transform;
            foreach (var text in zoneEntry.GetComponentsInChildren<Text>())
            {
                if (text.name == "Title")
                {
                    text.text = item.ZoneName;
                }
            }
            foreach (var btn in zoneEntry.GetComponentsInChildren<Button>())
            {
                var item1 = item;
                btn.onClick.AddListener(() =>
                {
                    ZoneSystem.SignalEnterZone(Game, new ZoneEventData()
                    {
                        Zone = item1,
                        ZoneId = item1.EntityId
                    });
                });
            }
        }
    }

    protected override void OnLoadData(GameReadyData data)
    {
        base.OnLoadData(data);
        for (var i = 0; i < _EntriesList.transform.childCount; i++)
        {
            var item = _EntriesList.transform.GetChild(i).gameObject;
            DestroyImmediate(item);
        }
    }
}
