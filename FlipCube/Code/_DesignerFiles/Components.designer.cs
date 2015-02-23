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


public class RollableBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private RollableAsset _Asset;
    
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
    
    public RollableAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            RollSpeed = _Asset.RollSpeed;
            RestState = _Asset.RestState;
            IsRolling = _Asset.IsRolling;
            Length = _Asset.Length;
            StartingPosition = _Asset.StartingPosition;
            IsSplit = _Asset.IsSplit;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/Rollable")]
public partial class Rollable {
}

public class CubeBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private CubeAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsSelected;
    
    public CubeAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Boolean IsSelected {
        get {
            return _IsSelected;
        }
        set {
            _IsSelected = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            IsSelected = _Asset.IsSelected;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/Cube")]
public partial class Cube {
}

public class MoveDirectionOnEnterBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private MoveDirectionOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _RollableId;
    
    [UnityEngine.SerializeField()]
    private CubeMoveDirection _MoveDirection;
    
    public MoveDirectionOnEnterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            RollableId = _Asset.RollableId;
            MoveDirection = _Asset.MoveDirection;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/MoveDirectionOnEnter")]
public partial class MoveDirectionOnEnter {
}

public class FollowOnSelectionBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private FollowOnSelectionAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Single _Distance;
    
    public FollowOnSelectionAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Single Distance {
        get {
            return _Distance;
        }
        set {
            _Distance = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Distance = _Asset.Distance;
        }
    }
}

[UnityEngine.AddComponentMenu("RenameMe/FollowOnSelection")]
public partial class FollowOnSelection {
}

public class PlateBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private PlateAsset _Asset;
    
    public PlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/Plate")]
public partial class Plate {
}

public class TeliporterBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TeliporterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    public TeliporterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Register = _Asset.Register;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/Teliporter")]
public partial class Teliporter {
}

public class TeliportableBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TeliportableAsset _Asset;
    
    public TeliportableAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/Teliportable")]
public partial class Teliportable {
}

public class TeliporterTargetBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TeliporterTargetAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    public TeliporterTargetAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Register = _Asset.Register;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/TeliporterTarget")]
public partial class TeliporterTarget {
}

public class GoalPlateBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private GoalPlateAsset _Asset;
    
    public GoalPlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/GoalPlate")]
public partial class GoalPlate {
}

public class SwitchPlateTriggerBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private SwitchPlateTriggerAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    public SwitchPlateTriggerAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Register = _Asset.Register;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/SwitchPlateTrigger")]
public partial class SwitchPlateTrigger {
}

public class TurnGravityOnEnterBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TurnGravityOnEnterAsset _Asset;
    
    public TurnGravityOnEnterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/TurnGravityOnEnter")]
public partial class TurnGravityOnEnter {
}

public class DisableColliderOnCollisionBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private DisableColliderOnCollisionAsset _Asset;
    
    public DisableColliderOnCollisionAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/DisableColliderOnCollision")]
public partial class DisableColliderOnCollision {
}

public class SwitchPlateTargetBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private SwitchPlateTargetAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private SwitchPlatePivot _PivotPoint;
    
    [UnityEngine.SerializeField()]
    private Boolean _On;
    
    [UnityEngine.SerializeField()]
    private Boolean _StartOn;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    public SwitchPlateTargetAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            PivotPoint = _Asset.PivotPoint;
            On = _Asset.On;
            StartOn = _Asset.StartOn;
            Register = _Asset.Register;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/SwitchPlateTarget")]
public partial class SwitchPlateTarget {
}

public class MoveLeftOnLeaveBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private MoveLeftOnLeaveAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Vector3 _Offset;
    
    public MoveLeftOnLeaveAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Vector3 Offset {
        get {
            return _Offset;
        }
        set {
            _Offset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Offset = _Asset.Offset;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/MoveLeftOnLeave")]
public partial class MoveLeftOnLeave {
}

public class TransporterPlateBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TransporterPlateAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Vector3 _MoveOffset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsOn;
    
    public TransporterPlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            MoveOffset = _Asset.MoveOffset;
            IsOn = _Asset.IsOn;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/TransporterPlate")]
public partial class TransporterPlate {
}

public class DissolvePlateBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private DissolvePlateAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsDissolved;
    
    public DissolvePlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Boolean IsDissolved {
        get {
            return _IsDissolved;
        }
        set {
            _IsDissolved = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            IsDissolved = _Asset.IsDissolved;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/DissolvePlate")]
public partial class DissolvePlate {
}

public class YingYangPlateBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private YingYangPlateAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private List<Int32> _TargetPlates;
    
    public YingYangPlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual List<Int32> TargetPlates {
        get {
            return _TargetPlates;
        }
        set {
            _TargetPlates = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Plates/YingYangPlate")]
public partial class YingYangPlate {
}

public class LevelBase : Invert.ECS.Unity.UnityComponent, Invert.ECS.ISavableComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private LevelAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _LevelNumber;
    
    [UnityEngine.SerializeField()]
    private Int32 _MaxXP;
    
    [UnityEngine.SerializeField()]
    private Int32 _MinimumMoves;
    
    [UnityEngine.SerializeField()]
    private Int32 _MovesTaken;
    
    [UnityEngine.SerializeField()]
    private Int32 _TimesPlayed;
    
    [UnityEngine.SerializeField()]
    private Int32 _BestScore;
    
    [UnityEngine.SerializeField()]
    private Int32 _BestTime;
    
    [UnityEngine.SerializeField()]
    private String _SceneName;
    
    [UnityEngine.SerializeField()]
    private DateTime _StartTime;
    
    [UnityEngine.SerializeField()]
    private LevelProgressStatus _CurrentStatus;
    
    [UnityEngine.SerializeField()]
    private LevelProgressStatus _BestStatus;
    
    private bool _isDirty;
    
    public LevelAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    [Invert.ECS.SaveableAttribute()]
    public virtual Int32 TimesPlayed {
        get {
            return _TimesPlayed;
        }
        set {
            _TimesPlayed = value;
            IsDirty = true;
        }
    }
    
    [Invert.ECS.SaveableAttribute()]
    public virtual Int32 BestScore {
        get {
            return _BestScore;
        }
        set {
            _BestScore = value;
            IsDirty = true;
        }
    }
    
    [Invert.ECS.SaveableAttribute()]
    public virtual Int32 BestTime {
        get {
            return _BestTime;
        }
        set {
            _BestTime = value;
            IsDirty = true;
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
    
    public virtual DateTime StartTime {
        get {
            return _StartTime;
        }
        set {
            _StartTime = value;
        }
    }
    
    public virtual LevelProgressStatus CurrentStatus {
        get {
            return _CurrentStatus;
        }
        set {
            _CurrentStatus = value;
        }
    }
    
    public virtual LevelProgressStatus BestStatus {
        get {
            return _BestStatus;
        }
        set {
            _BestStatus = value;
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            LevelNumber = _Asset.LevelNumber;
            MaxXP = _Asset.MaxXP;
            MinimumMoves = _Asset.MinimumMoves;
            MovesTaken = _Asset.MovesTaken;
            SceneName = _Asset.SceneName;
            StartTime = _Asset.StartTime;
            CurrentStatus = _Asset.CurrentStatus;
            BestStatus = _Asset.BestStatus;
        }
    }
}

[UnityEngine.AddComponentMenu("Levels/Level")]
public partial class Level {
}

public class LevelSpawnPointBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private LevelSpawnPointAsset _Asset;
    
    public LevelSpawnPointAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Levels/LevelSpawnPoint")]
public partial class LevelSpawnPoint {
}

public class LevelSceneBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private LevelSceneAsset _Asset;
    
    public LevelSceneAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Levels/LevelScene")]
public partial class LevelScene {
}

public class NotifyOnEnterBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private NotifyOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    public NotifyOnEnterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Message = _Asset.Message;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/NotifyOnEnter")]
public partial class NotifyOnEnter {
}

public class BasicGameBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private BasicGameAsset _Asset;
    
    public BasicGameAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/BasicGame")]
public partial class BasicGame {
}

public class EnterLevelOnEnterBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private EnterLevelOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _LevelId;
    
    public EnterLevelOnEnterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Int32 LevelId {
        get {
            return _LevelId;
        }
        set {
            _LevelId = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            LevelId = _Asset.LevelId;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/EnterLevelOnEnter")]
public partial class EnterLevelOnEnter {
}

public class CubeSpawnPointBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private CubeSpawnPointAsset _Asset;
    
    public CubeSpawnPointAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/CubeSpawnPoint")]
public partial class CubeSpawnPoint {
}

public class SwitchOnWithXpBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private SwitchOnWithXpAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    public SwitchOnWithXpAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Int32 RequiredXp {
        get {
            return _RequiredXp;
        }
        set {
            _RequiredXp = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            RequiredXp = _Asset.RequiredXp;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/SwitchOnWithXp")]
public partial class SwitchOnWithXp {
}

public class BackgroundSceneBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private BackgroundSceneAsset _Asset;
    
    public BackgroundSceneAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCube/BackgroundScene")]
public partial class BackgroundScene {
}

public class TweenPlateColorsBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TweenPlateColorsAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Color _IdleColor;
    
    [UnityEngine.SerializeField()]
    private Color _OnEnterColor;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsToggle;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsOn;
    
    public TweenPlateColorsAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            IdleColor = _Asset.IdleColor;
            OnEnterColor = _Asset.OnEnterColor;
            IsToggle = _Asset.IsToggle;
            IsOn = _Asset.IsOn;
        }
    }
}

[UnityEngine.AddComponentMenu("SpecialFX/TweenPlateColors")]
public partial class TweenPlateColors {
}

public class PlayerBase : Invert.ECS.Unity.UnityComponent, Invert.ECS.ISavableComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private PlayerAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private String _Name;
    
    [UnityEngine.SerializeField()]
    private Int32 _XP;
    
    [UnityEngine.SerializeField()]
    private Int32 _Rank;
    
    [UnityEngine.SerializeField()]
    private Int32 _TotalFlips;
    
    [UnityEngine.SerializeField()]
    private Int32 _CurrentLevelId;
    
    [UnityEngine.SerializeField()]
    private Int32 _CurrentZoneId;
    
    private bool _isDirty;
    
    public PlayerAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    [Invert.ECS.SaveableAttribute()]
    public virtual String Name {
        get {
            return _Name;
        }
        set {
            _Name = value;
            IsDirty = true;
        }
    }
    
    [Invert.ECS.SaveableAttribute()]
    [Invert.ECS.PlayerStatAttribute()]
    public virtual Int32 XP {
        get {
            return _XP;
        }
        set {
            _XP = value;
            IsDirty = true;
        }
    }
    
    [Invert.ECS.SaveableAttribute()]
    [Invert.ECS.PlayerStatAttribute()]
    public virtual Int32 Rank {
        get {
            return _Rank;
        }
        set {
            _Rank = value;
            IsDirty = true;
        }
    }
    
    [Invert.ECS.SaveableAttribute()]
    [Invert.ECS.PlayerStatAttribute()]
    public virtual Int32 TotalFlips {
        get {
            return _TotalFlips;
        }
        set {
            _TotalFlips = value;
            IsDirty = true;
        }
    }
    
    public virtual Int32 CurrentLevelId {
        get {
            return _CurrentLevelId;
        }
        set {
            _CurrentLevelId = value;
        }
    }
    
    [Invert.ECS.SaveableAttribute()]
    public virtual Int32 CurrentZoneId {
        get {
            return _CurrentZoneId;
        }
        set {
            _CurrentZoneId = value;
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            CurrentLevelId = _Asset.CurrentLevelId;
        }
    }
}

[UnityEngine.AddComponentMenu("Player/Player")]
public partial class Player {
}

public class ActiveWithXpBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ActiveWithXpAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    public ActiveWithXpAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Int32 RequiredXp {
        get {
            return _RequiredXp;
        }
        set {
            _RequiredXp = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            RequiredXp = _Asset.RequiredXp;
        }
    }
}

[UnityEngine.AddComponentMenu("Player/ActiveWithXp")]
public partial class ActiveWithXp {
}

public class ScoringBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ScoringAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _Score;
    
    public ScoringAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual Int32 Score {
        get {
            return _Score;
        }
        set {
            _Score = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Score = _Asset.Score;
        }
    }
}

[UnityEngine.AddComponentMenu("RenameMe/Scoring")]
public partial class Scoring {
}

public class ZoneBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ZoneAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private String _ZoneName;
    
    [UnityEngine.SerializeField()]
    private String _SceneName;
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    [UnityEngine.SerializeField()]
    private Int32 _Index;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsCurrent;
    
    [UnityEngine.SerializeField()]
    private List<Level> _Levels;
    
    public ZoneAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public virtual Int32 RequiredXp {
        get {
            return _RequiredXp;
        }
        set {
            _RequiredXp = value;
        }
    }
    
    public virtual Int32 Index {
        get {
            return _Index;
        }
        set {
            _Index = value;
        }
    }
    
    public virtual Boolean IsCurrent {
        get {
            return _IsCurrent;
        }
        set {
            _IsCurrent = value;
        }
    }
    
    public virtual List<Level> Levels {
        get {
            return _Levels;
        }
        set {
            _Levels = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            ZoneName = _Asset.ZoneName;
            SceneName = _Asset.SceneName;
            RequiredXp = _Asset.RequiredXp;
            Index = _Asset.Index;
            IsCurrent = _Asset.IsCurrent;
        }
    }
}

[UnityEngine.AddComponentMenu("Zones/Zone")]
public partial class Zone {
}

public class ZoneSceneBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ZoneSceneAsset _Asset;
    
    public ZoneSceneAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("Zones/ZoneScene")]
public partial class ZoneScene {
}

public class PlayerStatBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private PlayerStatAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private String _Key;
    
    [UnityEngine.SerializeField()]
    private Int32 _Value;
    
    public PlayerStatAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual String Key {
        get {
            return _Key;
        }
        set {
            _Key = value;
        }
    }
    
    public virtual Int32 Value {
        get {
            return _Value;
        }
        set {
            _Value = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            Key = _Asset.Key;
            Value = _Asset.Value;
        }
    }
}

[UnityEngine.AddComponentMenu("PlayerData/PlayerStat")]
public partial class PlayerStat {
}

public class WindowBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private WindowAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private FlipCubeWindow _WindowType;
    
    public WindowAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public virtual FlipCubeWindow WindowType {
        get {
            return _WindowType;
        }
        set {
            _WindowType = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            WindowType = _Asset.WindowType;
        }
    }
}

[UnityEngine.AddComponentMenu("UI/Window")]
public partial class Window {
}

public class ZonesWindowBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ZonesWindowAsset _Asset;
    
    public ZonesWindowAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("UI/ZonesWindow")]
public partial class ZonesWindow {
}

public class FriendsWindowBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private FriendsWindowAsset _Asset;
    
    public FriendsWindowAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("UI/FriendsWindow")]
public partial class FriendsWindow {
}

public class TutorialOnEnterBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TutorialOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _ArrowOver;
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    public TutorialOnEnterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            EntityId = _Asset.EntityId;
            ArrowOver = _Asset.ArrowOver;
            Message = _Asset.Message;
        }
    }
}

[UnityEngine.AddComponentMenu("Tutorial/TutorialOnEnter")]
public partial class TutorialOnEnter {
}
