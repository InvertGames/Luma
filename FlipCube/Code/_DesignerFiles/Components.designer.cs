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


public class RollableBase : Invert.ECS.Unity.UnityComponent, IRollable {
    
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
    
    private bool _isDirty;
    
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
            RollSpeed = _Asset.RollSpeed;
            RestState = _Asset.RestState;
            IsRolling = _Asset.IsRolling;
            Length = _Asset.Length;
            StartingPosition = _Asset.StartingPosition;
            IsSplit = _Asset.IsSplit;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("CubeSystem/Rollable")]
public partial class Rollable {
}

public class CubeBase : Invert.ECS.Unity.UnityComponent, ICube {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private CubeAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsSelected;
    
    private bool _isDirty;
    
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
            IsSelected = _Asset.IsSelected;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("CubeInputSystem/Cube")]
public partial class Cube {
}

public class MoveDirectionOnEnterBase : Invert.ECS.Unity.UnityComponent, IMoveDirectionOnEnter {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private MoveDirectionOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _RollableId;
    
    [UnityEngine.SerializeField()]
    private CubeMoveDirection _MoveDirection;
    
    private bool _isDirty;
    
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
            RollableId = _Asset.RollableId;
            MoveDirection = _Asset.MoveDirection;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("CubeInputSystem/MoveDirectionOnEnter")]
public partial class MoveDirectionOnEnter {
}

public class FollowOnSelectionBase : Invert.ECS.Unity.UnityComponent, IFollowOnSelection {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private FollowOnSelectionAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Single _Distance;
    
    private bool _isDirty;
    
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
            Distance = _Asset.Distance;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("CameraSystem/FollowOnSelection")]
public partial class FollowOnSelection {
}

public class PlateBase : Invert.ECS.Unity.UnityComponent, IPlate {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private PlateAsset _Asset;
    
    private bool _isDirty;
    
    public PlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("PlateSystem/Plate")]
public partial class Plate {
}

public class TeliporterBase : Invert.ECS.Unity.UnityComponent, ITeliporter {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TeliporterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    private bool _isDirty;
    
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
            Register = _Asset.Register;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("TeliporterSystem/Teliporter")]
public partial class Teliporter {
}

public class TeliportableBase : Invert.ECS.Unity.UnityComponent, ITeliportable {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TeliportableAsset _Asset;
    
    private bool _isDirty;
    
    public TeliportableAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("TeliporterSystem/Teliportable")]
public partial class Teliportable {
}

public class TeliporterTargetBase : Invert.ECS.Unity.UnityComponent, ITeliporterTarget {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TeliporterTargetAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    private bool _isDirty;
    
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
            Register = _Asset.Register;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("TeliporterSystem/TeliporterTarget")]
public partial class TeliporterTarget {
}

public class GoalPlateBase : Invert.ECS.Unity.UnityComponent, IGoalPlate {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private GoalPlateAsset _Asset;
    
    private bool _isDirty;
    
    public GoalPlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("GoalPlateSystem/GoalPlate")]
public partial class GoalPlate {
}

public class SwitchPlateTriggerBase : Invert.ECS.Unity.UnityComponent, ISwitchPlateTrigger {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private SwitchPlateTriggerAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private PlateRegister _Register;
    
    private bool _isDirty;
    
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
            Register = _Asset.Register;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("SwitchPlateSystem/SwitchPlateTrigger")]
public partial class SwitchPlateTrigger {
}

public class TurnGravityOnEnterBase : Invert.ECS.Unity.UnityComponent, ITurnGravityOnEnter {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TurnGravityOnEnterAsset _Asset;
    
    private bool _isDirty;
    
    public TurnGravityOnEnterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

public partial class TurnGravityOnEnter {
}

public class DisableColliderOnCollisionBase : Invert.ECS.Unity.UnityComponent, IDisableColliderOnCollision {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private DisableColliderOnCollisionAsset _Asset;
    
    private bool _isDirty;
    
    public DisableColliderOnCollisionAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("PlateSystem/DisableColliderOnCollision")]
public partial class DisableColliderOnCollision {
}

public class SwitchPlateTargetBase : Invert.ECS.Unity.UnityComponent, ISwitchPlateTarget {
    
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
    
    private bool _isDirty;
    
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
            PivotPoint = _Asset.PivotPoint;
            On = _Asset.On;
            StartOn = _Asset.StartOn;
            Register = _Asset.Register;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("SwitchPlateSystem/SwitchPlateTarget")]
public partial class SwitchPlateTarget {
}

public class MoveLeftOnLeaveBase : Invert.ECS.Unity.UnityComponent, IMoveLeftOnLeave {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private MoveLeftOnLeaveAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Vector3 _Offset;
    
    private bool _isDirty;
    
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
            Offset = _Asset.Offset;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("ShiftingPlate/MoveLeftOnLeave")]
public partial class MoveLeftOnLeave {
}

public class TransporterPlateBase : Invert.ECS.Unity.UnityComponent, ITransporterPlate {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TransporterPlateAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Vector3 _MoveOffset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsOn;
    
    private bool _isDirty;
    
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
            MoveOffset = _Asset.MoveOffset;
            IsOn = _Asset.IsOn;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("ShiftingPlate/TransporterPlate")]
public partial class TransporterPlate {
}

public class DissolvePlateBase : Invert.ECS.Unity.UnityComponent, IDissolvePlate {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private DissolvePlateAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Boolean _IsDissolved;
    
    private bool _isDirty;
    
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
            IsDissolved = _Asset.IsDissolved;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("DissolvePlateSystem/DissolvePlate")]
public partial class DissolvePlate {
}

public class YingYangPlateBase : Invert.ECS.Unity.UnityComponent, IYingYangPlate {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private YingYangPlateAsset _Asset;
    
    private bool _isDirty;
    
    [UnityEngine.SerializeField()]
    private Int32[] _TargetPlates;
    
    public YingYangPlateAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
    
    public virtual Int32[] TargetPlates {
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
            TargetPlates = _Asset.TargetPlates;
        }
    }
}

[UnityEngine.AddComponentMenu("PlateSystem/YingYangPlate")]
public partial class YingYangPlate {
}

public class LevelBase : Invert.ECS.Unity.UnityComponent, ILevel, Invert.ECS.ISavableComponent {
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            LevelNumber = _Asset.LevelNumber;
            MaxXP = _Asset.MaxXP;
            MinimumMoves = _Asset.MinimumMoves;
            MovesTaken = _Asset.MovesTaken;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("LevelSystem/Level")]
public partial class Level {
}

public class LevelSpawnPointBase : Invert.ECS.Unity.UnityComponent, ILevelSpawnPoint {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private LevelSpawnPointAsset _Asset;
    
    private bool _isDirty;
    
    public LevelSpawnPointAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("BasicGameSystem/LevelSpawnPoint")]
public partial class LevelSpawnPoint {
}

public class NotifyOnEnterBase : Invert.ECS.Unity.UnityComponent, INotifyOnEnter {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private NotifyOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    private bool _isDirty;
    
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
            Message = _Asset.Message;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCubeNotifications/NotifyOnEnter")]
public partial class NotifyOnEnter {
}

public class BasicGameBase : Invert.ECS.Unity.UnityComponent, IBasicGame {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private BasicGameAsset _Asset;
    
    private bool _isDirty;
    
    public BasicGameAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("BasicGameSystem/BasicGame")]
public partial class BasicGame {
}

public class EnterLevelOnEnterBase : Invert.ECS.Unity.UnityComponent, IEnterLevelOnEnter {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private EnterLevelOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private String _SceneName;
    
    private bool _isDirty;
    
    public EnterLevelOnEnterAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
            SceneName = _Asset.SceneName;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCubeSystem/EnterLevelOnEnter")]
public partial class EnterLevelOnEnter {
}

public class CubeSpawnPointBase : Invert.ECS.Unity.UnityComponent, ICubeSpawnPoint {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private CubeSpawnPointAsset _Asset;
    
    private bool _isDirty;
    
    public CubeSpawnPointAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("BasicGameSystem/CubeSpawnPoint")]
public partial class CubeSpawnPoint {
}

public class SwitchOnWithXpBase : Invert.ECS.Unity.UnityComponent, ISwitchOnWithXp {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private SwitchOnWithXpAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    private bool _isDirty;
    
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
            RequiredXp = _Asset.RequiredXp;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("SwitchPlateSystem/SwitchOnWithXp")]
public partial class SwitchOnWithXp {
}

public class TweenPlateColorsBase : Invert.ECS.Unity.UnityComponent, ITweenPlateColors {
    
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
    
    private bool _isDirty;
    
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
            IdleColor = _Asset.IdleColor;
            OnEnterColor = _Asset.OnEnterColor;
            IsToggle = _Asset.IsToggle;
            IsOn = _Asset.IsOn;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("SpecialFXSystem/TweenPlateColors")]
public partial class TweenPlateColors {
}

public class WindowBase : Invert.ECS.Unity.UnityComponent, IWindow {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private WindowAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private FlipCubeWindow _WindowType;
    
    private bool _isDirty;
    
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
            WindowType = _Asset.WindowType;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("WindowSystem/Window")]
public partial class Window {
}

public class CloseWindowOnClickBase : Invert.ECS.Unity.UnityComponent, ICloseWindowOnClick {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private CloseWindowOnClickAsset _Asset;
    
    private bool _isDirty;
    
    public CloseWindowOnClickAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

[UnityEngine.AddComponentMenu("WindowSystem/CloseWindowOnClick")]
public partial class CloseWindowOnClick {
}

public class ZonesWindowBase : Invert.ECS.Unity.UnityComponent, IZonesWindow {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ZonesWindowAsset _Asset;
    
    private bool _isDirty;
    
    public ZonesWindowAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

public partial class ZonesWindow {
}

public class FriendsWindowBase : Invert.ECS.Unity.UnityComponent, IFriendsWindow {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private FriendsWindowAsset _Asset;
    
    private bool _isDirty;
    
    public FriendsWindowAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
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
        }
    }
}

public partial class FriendsWindow {
}

public class PlayerBase : Invert.ECS.Unity.UnityComponent, IPlayer, Invert.ECS.ISavableComponent {
    
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
    
    private bool _isDirty;
    
    public PlayerAsset Asset {
        get {
            return _Asset;
        }
        set {
            _Asset = value;
        }
    }
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            Name = _Asset.Name;
            XP = _Asset.XP;
            Rank = _Asset.Rank;
            TotalFlips = _Asset.TotalFlips;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("SwitchPlateSystem/Player")]
public partial class Player {
}

public class ActiveWithXpBase : Invert.ECS.Unity.UnityComponent, IActiveWithXp {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ActiveWithXpAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _RequiredXp;
    
    private bool _isDirty;
    
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
            RequiredXp = _Asset.RequiredXp;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("PlayerSystem/ActiveWithXp")]
public partial class ActiveWithXp {
}

public class ScoringBase : Invert.ECS.Unity.UnityComponent, IScoring {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ScoringAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _Score;
    
    private bool _isDirty;
    
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
            Score = _Asset.Score;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("ScoringSystem/Scoring")]
public partial class Scoring {
}

public class ZoneBase : Invert.ECS.Unity.UnityComponent, IZone {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private ZoneAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private String _ZoneName;
    
    private bool _isDirty;
    
    [UnityEngine.SerializeField()]
    private Int32[] _Levels;
    
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
    
    public override void Awake() {
        if (_Asset != null) {
            ZoneName = _Asset.ZoneName;
            EntityId = _Asset.EntityId;
            Levels = _Asset.Levels.Select(p=>p.EntityId).ToArray();
        }
    }
}

[UnityEngine.AddComponentMenu("FlipCubeGameSystem/Zone")]
public partial class Zone {
}

public class TutorialOnEnterBase : Invert.ECS.Unity.UnityComponent, ITutorialOnEnter {
    
    [UnityEngine.SerializeField()]
    [UnityEngine.HideInInspector()]
    private TutorialOnEnterAsset _Asset;
    
    [UnityEngine.SerializeField()]
    private Int32 _ArrowOver;
    
    [UnityEngine.SerializeField()]
    private String _Message;
    
    private bool _isDirty;
    
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
            ArrowOver = _Asset.ArrowOver;
            Message = _Asset.Message;
            EntityId = _Asset.EntityId;
        }
    }
}

[UnityEngine.AddComponentMenu("TutorialSystem/TutorialOnEnter")]
public partial class TutorialOnEnter {
}
