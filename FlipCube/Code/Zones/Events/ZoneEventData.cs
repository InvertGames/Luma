using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class ZoneEventData : ZoneEventDataBase {
    [SerializeField]
    private Zone _zone;

    public Zone Zone
    {
        get { return _zone; }
        set { _zone = value; }
    }
}
