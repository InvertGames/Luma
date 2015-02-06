using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


public class EnterLevelEventData : EnterLevelEventDataBase {
    public LevelAsset LevelData { get; set; }
}
