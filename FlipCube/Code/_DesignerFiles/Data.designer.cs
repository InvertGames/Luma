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
public class RollableData : IRollable {
    
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
    
    private bool _isDirty;
    
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
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class CubeData : ICube {
    
    [UnityEngine.SerializeField()]
    private Boolean _IsSelected;
    
    private bool _isDirty;
    
    public virtual Boolean IsSelected {
        get {
            return _IsSelected;
        }
        set {
            _IsSelected = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class MoveDirectionOnEnterData : IMoveDirectionOnEnter {
    
    [UnityEngine.SerializeField()]
    private Int32 _RollableId;
    
    [UnityEngine.SerializeField()]
    private CubeMoveDirection _MoveDirection;
    
    private bool _isDirty;
    
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
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class FollowOnSelectionData : IFollowOnSelection {
    
    [UnityEngine.SerializeField()]
    private Single _Distance;
    
    private bool _isDirty;
    
    public virtual Single Distance {
        get {
            return _Distance;
        }
        set {
            _Distance = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class PlateData : IPlate {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class TeliporterData : ITeliporter {
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    private bool _isDirty;
    
    public virtual PlateRegister Register {
        get {
            return _Register;
        }
        set {
            _Register = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class TeliportableData : ITeliportable {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class TeliporterTargetData : ITeliporterTarget {
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    private bool _isDirty;
    
    public virtual PlateRegister Register {
        get {
            return _Register;
        }
        set {
            _Register = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class GoalPlateData : IGoalPlate {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class SwitchPlateTriggerData : ISwitchPlateTrigger {
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    private bool _isDirty;
    
    public virtual PlateRegister Register {
        get {
            return _Register;
        }
        set {
            _Register = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class TurnGravityOnEnterData : ITurnGravityOnEnter {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class DisableColliderOnCollisionData : IDisableColliderOnCollision {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class SwitchPlateTargetData : ISwitchPlateTarget {
    
    [UnityEngine.SerializeField()]
    private SwitchPlatePivot _PivotPoint;
    
    [UnityEngine.SerializeField()]
    private Boolean _On;
    
    [UnityEngine.SerializeField()]
    private Boolean _StartOn;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    private bool _isDirty;
    
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
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class MoveLeftOnLeaveData : IMoveLeftOnLeave {
    
    [UnityEngine.SerializeField()]
    private Vector3 _Offset;
    
    private bool _isDirty;
    
    public virtual Vector3 Offset {
        get {
            return _Offset;
        }
        set {
            _Offset = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class TransporterPlateData : ITransporterPlate {
    
    [UnityEngine.SerializeField()]
    private Vector3 _MoveOffset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsOn;
    
    private bool _isDirty;
    
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
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class DissolvePlateData : IDissolvePlate {
    
    [UnityEngine.SerializeField()]
    private Boolean _IsDissolved;
    
    private bool _isDirty;
    
    public virtual Boolean IsDissolved {
        get {
            return _IsDissolved;
        }
        set {
            _IsDissolved = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class YingYangPlateData : IYingYangPlate {
    
    private bool _isDirty;
    
    [UnityEngine.SerializeField()]
    private Int32[] _TargetPlates;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
    
    public virtual Int32[] TargetPlates {
        get {
            return _TargetPlates;
        }
        set {
            _TargetPlates = value;
        }
    }
}

[System.SerializableAttribute()]
public class LevelData : ILevel {
    
    [UnityEngine.SerializeField()]
    private Int32 _LevelNumber;
    
    [UnityEngine.SerializeField()]
    private Int32 _MaxXP;
    
    [UnityEngine.SerializeField()]
    private Int32 _MinimumMoves;
    
    [UnityEngine.SerializeField()]
    private Int32 _MovesTaken;
    
    private bool _isDirty;
    
    public virtual Int32 LevelNumber {
        get {
            return _LevelNumber;
        }
        set {
            _LevelNumber = value;
            IsDirty = true;
        }
    }
    
    public virtual Int32 MaxXP {
        get {
            return _MaxXP;
        }
        set {
            _MaxXP = value;
            IsDirty = true;
        }
    }
    
    public virtual Int32 MinimumMoves {
        get {
            return _MinimumMoves;
        }
        set {
            _MinimumMoves = value;
            IsDirty = true;
        }
    }
    
    public virtual Int32 MovesTaken {
        get {
            return _MovesTaken;
        }
        set {
            _MovesTaken = value;
            IsDirty = true;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class LevelSpawnPointData : ILevelSpawnPoint {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class NotifyOnEnterData : INotifyOnEnter {
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    private bool _isDirty;
    
    public virtual String Message {
        get {
            return _Message;
        }
        set {
            _Message = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class BasicGameData : IBasicGame {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class EnterLevelOnEnterData : IEnterLevelOnEnter {
    
    [UnityEngine.SerializeField()]
    private String _SceneName;
    
    private bool _isDirty;
    
    public virtual String SceneName {
        get {
            return _SceneName;
        }
        set {
            _SceneName = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class CubeSpawnPointData : ICubeSpawnPoint {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class SwitchOnWithXpData : ISwitchOnWithXp {
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    private bool _isDirty;
    
    public virtual Int32 RequiredXp {
        get {
            return _RequiredXp;
        }
        set {
            _RequiredXp = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class TweenPlateColorsData : ITweenPlateColors {
    
    [UnityEngine.SerializeField()]
    private Color _IdleColor;
    
    [UnityEngine.SerializeField()]
    private Color _OnEnterColor;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsToggle;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsOn;
    
    private bool _isDirty;
    
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
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class WindowData : IWindow {
    
    [UnityEngine.SerializeField()]
    private FlipCubeWindow _WindowType;
    
    private bool _isDirty;
    
    public virtual FlipCubeWindow WindowType {
        get {
            return _WindowType;
        }
        set {
            _WindowType = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class CloseWindowOnClickData : ICloseWindowOnClick {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class ZonesWindowData : IZonesWindow {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class FriendsWindowData : IFriendsWindow {
    
    private bool _isDirty;
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class PlayerData : IPlayer {
    
    [UnityEngine.SerializeField()]
    private String _Name;
    
    [UnityEngine.SerializeField()]
    private Int32 _XP;
    
    [UnityEngine.SerializeField()]
    private Int32 _Rank;
    
    [UnityEngine.SerializeField()]
    private Int32 _TotalFlips;
    
    private bool _isDirty;
    
    public virtual String Name {
        get {
            return _Name;
        }
        set {
            _Name = value;
            IsDirty = true;
        }
    }
    
    public virtual Int32 XP {
        get {
            return _XP;
        }
        set {
            _XP = value;
            IsDirty = true;
        }
    }
    
    public virtual Int32 Rank {
        get {
            return _Rank;
        }
        set {
            _Rank = value;
            IsDirty = true;
        }
    }
    
    public virtual Int32 TotalFlips {
        get {
            return _TotalFlips;
        }
        set {
            _TotalFlips = value;
            IsDirty = true;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class ActiveWithXpData : IActiveWithXp {
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    private bool _isDirty;
    
    public virtual Int32 RequiredXp {
        get {
            return _RequiredXp;
        }
        set {
            _RequiredXp = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class ScoringData : IScoring {
    
    [UnityEngine.SerializeField()]
    private Int32 _Score;
    
    private bool _isDirty;
    
    public virtual Int32 Score {
        get {
            return _Score;
        }
        set {
            _Score = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}

[System.SerializableAttribute()]
public class ZoneData : IZone {
    
    [UnityEngine.SerializeField()]
    private String _ZoneName;
    
    private bool _isDirty;
    
    [UnityEngine.SerializeField()]
    private Int32[] _Levels;
    
    public virtual String ZoneName {
        get {
            return _ZoneName;
        }
        set {
            _ZoneName = value;
        }
    }
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
    
    public virtual Int32[] Levels {
        get {
            return _Levels;
        }
        set {
            _Levels = value;
        }
    }
}

[System.SerializableAttribute()]
public class TutorialOnEnterData : ITutorialOnEnter {
    
    [UnityEngine.SerializeField()]
    private Int32 _ArrowOver;
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    private bool _isDirty;
    
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
    
    public bool IsDirty {
        get {
            return _isDirty;
        }
        set {
            _isDirty = value;
        }
    }
}
