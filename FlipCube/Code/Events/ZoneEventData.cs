using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class ZoneEventData : ZoneEventDataBase {
    [SerializeField]
    private ZoneAsset _zone;

    public ZoneAsset Zone
    {
        get { return _zone; }
        set { _zone = value; }
    }
}
