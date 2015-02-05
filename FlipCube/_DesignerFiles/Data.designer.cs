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


[System.SerializableAttribute()]
public class RollableData {
    
    [UnityEngine.SerializeField()]
    private Single _RollSpeed;
    
    [UnityEngine.SerializeField()]
    private RollerState _RestState;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsRolling;
    
    [UnityEngine.SerializeField()]
    private Int32 _Length;
    
    [UnityEngine.SerializeField()]
    private Vector3 _StartingPosition;
    
    public virtual Single RollSpeed {
        get {
            return _RollSpeed;
        }
        set {
            _RollSpeed = value;
        }
    }
    
    public virtual RollerState RestState {
        get {
            return _RestState;
        }
        set {
            _RestState = value;
        }
    }
    
    public virtual Boolean IsRolling {
        get {
            return _IsRolling;
        }
        set {
            _IsRolling = value;
        }
    }
    
    public virtual Int32 Length {
        get {
            return _Length;
        }
        set {
            _Length = value;
        }
    }
    
    public virtual Vector3 StartingPosition {
        get {
            return _StartingPosition;
        }
        set {
            _StartingPosition = value;
        }
    }
}

[System.SerializableAttribute()]
public class CubeData {
    
    [UnityEngine.SerializeField()]
    private Boolean _IsSelected;
    
    public virtual Boolean IsSelected {
        get {
            return _IsSelected;
        }
        set {
            _IsSelected = value;
        }
    }
}

[System.SerializableAttribute()]
public class MoveDirectionOnEnterData {
    
    [UnityEngine.SerializeField()]
    private Int32 _RollableId;
    
    [UnityEngine.SerializeField()]
    private MoveDirection _MoveDirection;
    
    public virtual Int32 RollableId {
        get {
            return _RollableId;
        }
        set {
            _RollableId = value;
        }
    }
    
    public virtual MoveDirection MoveDirection {
        get {
            return _MoveDirection;
        }
        set {
            _MoveDirection = value;
        }
    }
}

[System.SerializableAttribute()]
public class FollowOnSelectionData {
    
    [UnityEngine.SerializeField()]
    private Single _Distance;
    
    public virtual Single Distance {
        get {
            return _Distance;
        }
        set {
            _Distance = value;
        }
    }
}

[System.SerializableAttribute()]
public class PlateData {
}

[System.SerializableAttribute()]
public class TeliporterData {
    
    [UnityEngine.SerializeField()]
    private Int32 _PlateId;
    
    public virtual Int32 PlateId {
        get {
            return _PlateId;
        }
        set {
            _PlateId = value;
        }
    }
}

[System.SerializableAttribute()]
public class TeliportableData {
}

[System.SerializableAttribute()]
public class TeliporterTargetData {
}

[System.SerializableAttribute()]
public class GoalPlateData {
}

[System.SerializableAttribute()]
public class SwitchPlateTriggerData {
    
    [UnityEngine.SerializeField()]
    private Int32[] _Targets;
    
    public virtual Int32[] Targets {
        get {
            return _Targets;
        }
        set {
            _Targets = value;
        }
    }
}

[System.SerializableAttribute()]
public class TurnGravityOnEnterData {
}

[System.SerializableAttribute()]
public class DisableColliderOnCollisionData {
}

[System.SerializableAttribute()]
public class SwitchPlateTargetData {
    
    [UnityEngine.SerializeField()]
    private SwitchPlatePivot _PivotPoint;
    
    [UnityEngine.SerializeField()]
    private Boolean _On;
    
    [UnityEngine.SerializeField()]
    private Boolean _StartOn;
    
    public virtual SwitchPlatePivot PivotPoint {
        get {
            return _PivotPoint;
        }
        set {
            _PivotPoint = value;
        }
    }
    
    public virtual Boolean On {
        get {
            return _On;
        }
        set {
            _On = value;
        }
    }
    
    public virtual Boolean StartOn {
        get {
            return _StartOn;
        }
        set {
            _StartOn = value;
        }
    }
}

[System.SerializableAttribute()]
public class MoveLeftOnLeaveData {
    
    [UnityEngine.SerializeField()]
    private Vector3 _Offset;
    
    public virtual Vector3 Offset {
        get {
            return _Offset;
        }
        set {
            _Offset = value;
        }
    }
}

[System.SerializableAttribute()]
public class LevelCompleteOnContactData {
    
    [UnityEngine.SerializeField()]
    private Int32 _Number;
    
    public virtual Int32 Number {
        get {
            return _Number;
        }
        set {
            _Number = value;
        }
    }
}

[System.SerializableAttribute()]
public class RestartOnMouseDownData {
}

[System.SerializableAttribute()]
public class EndOnMouseDownData {
}

[System.SerializableAttribute()]
public class RestartOnCollisionData {
}

[System.SerializableAttribute()]
public class FailOnCollisionData {
}

[System.SerializableAttribute()]
public class NotifyOnEnterData {
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    public virtual String Message {
        get {
            return _Message;
        }
        set {
            _Message = value;
        }
    }
}

[System.SerializableAttribute()]
public class TweenPlateColorsData {
    
    [UnityEngine.SerializeField()]
    private Color _IdleColor;
    
    [UnityEngine.SerializeField()]
    private Color _OnEnterColor;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsToggle;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsOn;
    
    public virtual Color IdleColor {
        get {
            return _IdleColor;
        }
        set {
            _IdleColor = value;
        }
    }
    
    public virtual Color OnEnterColor {
        get {
            return _OnEnterColor;
        }
        set {
            _OnEnterColor = value;
        }
    }
    
    public virtual Boolean IsToggle {
        get {
            return _IsToggle;
        }
        set {
            _IsToggle = value;
        }
    }
    
    public virtual Boolean IsOn {
        get {
            return _IsOn;
        }
        set {
            _IsOn = value;
        }
    }
}
