using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public partial class Level : LevelBase
{
    public TimeSpan CurrentTime
    {
        get { return (DateTime.Now.Subtract(StartTime)); }
    }
}
