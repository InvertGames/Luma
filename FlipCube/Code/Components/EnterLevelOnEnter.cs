using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public partial class EnterLevelOnEnter : EnterLevelOnEnterBase {
    [SerializeField]
    private LevelAsset _level;

    public LevelAsset Level
    {
        get { return _level; }
        set { _level = value; }
    }
}
