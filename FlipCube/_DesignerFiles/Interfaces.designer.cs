// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public interface IRollable {
    
    
    
    
    
    
    Single RollSpeed {
        get;
        set;
    }
    
    RollerState RestState {
        get;
        set;
    }
    
    Boolean IsRolling {
        get;
        set;
    }
    
    Int32 Length {
        get;
        set;
    }
    
    Vector3 StartingPosition {
        get;
        set;
    }
}

public interface ICube {
    
    
    Boolean IsSelected {
        get;
        set;
    }
}

public interface IMoveDirectionOnEnter {
    
    
    
    Int32 RollableId {
        get;
        set;
    }
    
    CubeMoveDirection MoveDirection {
        get;
        set;
    }
}

public interface IFollowOnSelection {
    
    
    Single Distance {
        get;
        set;
    }
}

public interface IPlate {
}

public interface ITeliporter {
    
    
    Int32 PlateId {
        get;
        set;
    }
}

public interface ITeliportable {
}

public interface ITeliporterTarget {
}

public interface IGoalPlate {
}

public interface ISwitchPlateTrigger {
    
    
    Int32[] Targets {
        get;
        set;
    }
}

public interface ITurnGravityOnEnter {
}

public interface IDisableColliderOnCollision {
}

public interface ISwitchPlateTarget {
    
    
    
    
    SwitchPlatePivot PivotPoint {
        get;
        set;
    }
    
    Boolean On {
        get;
        set;
    }
    
    Boolean StartOn {
        get;
        set;
    }
}

public interface IMoveLeftOnLeave {
    
    
    Vector3 Offset {
        get;
        set;
    }
}

public interface ILevelCompleteOnContact {
    
    
    Int32 Number {
        get;
        set;
    }
}

public interface IRestartOnMouseDown {
}

public interface IEndOnMouseDown {
}

public interface IRestartOnCollision {
}

public interface IFailOnCollision {
}

public interface INotifyOnEnter {
    
    
    String Message {
        get;
        set;
    }
}

public interface ITweenPlateColors {
    
    
    
    
    
    Color IdleColor {
        get;
        set;
    }
    
    Color OnEnterColor {
        get;
        set;
    }
    
    Boolean IsToggle {
        get;
        set;
    }
    
    Boolean IsOn {
        get;
        set;
    }
}
