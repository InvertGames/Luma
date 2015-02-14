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


public partial class RollableAsset : Invert.ECS.ComponentAsset {
    
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
    
    [UnityEngine.SerializeField()]
    private Boolean _IsSplit;
    
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
    
    public virtual Boolean IsSplit {
        get {
            return _IsSplit;
        }
        set {
            _IsSplit = value;
        }
    }
}

public partial class CubeAsset : Invert.ECS.ComponentAsset {
    
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

public partial class MoveDirectionOnEnterAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32 _RollableId;
    
    [UnityEngine.SerializeField()]
    private CubeMoveDirection _MoveDirection;
    
    public virtual Int32 RollableId {
        get {
            return _RollableId;
        }
        set {
            _RollableId = value;
        }
    }
    
    public virtual CubeMoveDirection MoveDirection {
        get {
            return _MoveDirection;
        }
        set {
            _MoveDirection = value;
        }
    }
}

public partial class FollowOnSelectionAsset : Invert.ECS.ComponentAsset {
    
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

public partial class PlateAsset : Invert.ECS.ComponentAsset {
}

public partial class TeliporterAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    public virtual PlateRegister Register {
        get {
            return _Register;
        }
        set {
            _Register = value;
        }
    }
}

public partial class TeliportableAsset : Invert.ECS.ComponentAsset {
}

public partial class TeliporterTargetAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    public virtual PlateRegister Register {
        get {
            return _Register;
        }
        set {
            _Register = value;
        }
    }
}

public partial class GoalPlateAsset : Invert.ECS.ComponentAsset {
}

public partial class SwitchPlateTriggerAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    public virtual PlateRegister Register {
        get {
            return _Register;
        }
        set {
            _Register = value;
        }
    }
}

public partial class TurnGravityOnEnterAsset : Invert.ECS.ComponentAsset {
}

public partial class DisableColliderOnCollisionAsset : Invert.ECS.ComponentAsset {
}

public partial class SwitchPlateTargetAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private SwitchPlatePivot _PivotPoint;
    
    [UnityEngine.SerializeField()]
    private Boolean _On;
    
    [UnityEngine.SerializeField()]
    private Boolean _StartOn;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
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
    
    public virtual PlateRegister Register {
        get {
            return _Register;
        }
        set {
            _Register = value;
        }
    }
}

public partial class MoveLeftOnLeaveAsset : Invert.ECS.ComponentAsset {
    
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

public partial class TransporterPlateAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Vector3 _MoveOffset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsOn;
    
    public virtual Vector3 MoveOffset {
        get {
            return _MoveOffset;
        }
        set {
            _MoveOffset = value;
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

public partial class DissolvePlateAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Boolean _IsDissolved;
    
    public virtual Boolean IsDissolved {
        get {
            return _IsDissolved;
        }
        set {
            _IsDissolved = value;
        }
    }
}

public partial class YingYangPlateAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32[] _TargetPlates;
    
    public virtual Int32[] TargetPlates {
        get {
            return _TargetPlates;
        }
        set {
            _TargetPlates = value;
        }
    }
}

public partial class LevelAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32 _LevelNumber;
    
    [UnityEngine.SerializeField()]
    private Int32 _MaxXP;
    
    [UnityEngine.SerializeField()]
    private Int32 _MinimumMoves;
    
    [UnityEngine.SerializeField()]
    private Int32 _MovesTaken;
    
    [UnityEngine.SerializeField()]
    private String _SceneName;
    
    public virtual Int32 LevelNumber {
        get {
            return _LevelNumber;
        }
        set {
            _LevelNumber = value;
        }
    }
    
    public virtual Int32 MaxXP {
        get {
            return _MaxXP;
        }
        set {
            _MaxXP = value;
        }
    }
    
    public virtual Int32 MinimumMoves {
        get {
            return _MinimumMoves;
        }
        set {
            _MinimumMoves = value;
        }
    }
    
    public virtual Int32 MovesTaken {
        get {
            return _MovesTaken;
        }
        set {
            _MovesTaken = value;
        }
    }
    
    public virtual String SceneName {
        get {
            return _SceneName;
        }
        set {
            _SceneName = value;
        }
    }
}

public partial class LevelSpawnPointAsset : Invert.ECS.ComponentAsset {
}

public partial class LevelSceneAsset : Invert.ECS.ComponentAsset {
}

public partial class NotifyOnEnterAsset : Invert.ECS.ComponentAsset {
    
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

public partial class BasicGameAsset : Invert.ECS.ComponentAsset {
}

public partial class EnterLevelOnEnterAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32 _LevelId;
    
    public virtual Int32 LevelId {
        get {
            return _LevelId;
        }
        set {
            _LevelId = value;
        }
    }
}

public partial class CubeSpawnPointAsset : Invert.ECS.ComponentAsset {
}

public partial class SwitchOnWithXpAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    public virtual Int32 RequiredXp {
        get {
            return _RequiredXp;
        }
        set {
            _RequiredXp = value;
        }
    }
}

public partial class TweenPlateColorsAsset : Invert.ECS.ComponentAsset {
    
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

public partial class WindowAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private FlipCubeWindow _WindowType;
    
    public virtual FlipCubeWindow WindowType {
        get {
            return _WindowType;
        }
        set {
            _WindowType = value;
        }
    }
}

public partial class CloseWindowOnClickAsset : Invert.ECS.ComponentAsset {
}

public partial class ZonesWindowAsset : Invert.ECS.ComponentAsset {
}

public partial class FriendsWindowAsset : Invert.ECS.ComponentAsset {
}

public partial class PlayerAsset : Invert.ECS.ComponentAsset {
}

public partial class ActiveWithXpAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    public virtual Int32 RequiredXp {
        get {
            return _RequiredXp;
        }
        set {
            _RequiredXp = value;
        }
    }
}

public partial class ScoringAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32 _Score;
    
    public virtual Int32 Score {
        get {
            return _Score;
        }
        set {
            _Score = value;
        }
    }
}

public partial class ZoneAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private String _ZoneName;
    
    [UnityEngine.SerializeField()]
    private String _SceneName;
    
    [UnityEngine.SerializeField()]
    private LevelAsset[] _Levels;
    
    public virtual String ZoneName {
        get {
            return _ZoneName;
        }
        set {
            _ZoneName = value;
        }
    }
    
    public virtual String SceneName {
        get {
            return _SceneName;
        }
        set {
            _SceneName = value;
        }
    }
    
    public virtual LevelAsset[] Levels {
        get {
            return _Levels;
        }
        set {
            _Levels = value;
        }
    }
}

public partial class ZoneSceneAsset : Invert.ECS.ComponentAsset {
}

public partial class TutorialOnEnterAsset : Invert.ECS.ComponentAsset {
    
    [UnityEngine.SerializeField()]
    private Int32 _ArrowOver;
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    public virtual Int32 ArrowOver {
        get {
            return _ArrowOver;
        }
        set {
            _ArrowOver = value;
        }
    }
    
    public virtual String Message {
        get {
            return _Message;
        }
        set {
            _Message = value;
        }
    }
}
