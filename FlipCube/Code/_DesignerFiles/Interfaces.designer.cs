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
    
    Boolean IsSplit {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ICube {
    
    
    
    Boolean IsSelected {
        get;
        set;
    }
    
    bool IsDirty {
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
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IFollowOnSelection {
    
    
    
    Single Distance {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IPlate {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ITeliporter {
    
    
    
    PlateRegister Register {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ITeliportable {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ITeliporterTarget {
    
    
    
    PlateRegister Register {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IGoalPlate {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ISwitchPlateTrigger {
    
    
    
    PlateRegister Register {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ITurnGravityOnEnter {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IDisableColliderOnCollision {
    
    
    bool IsDirty {
        get;
        set;
    }
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
    
    PlateRegister Register {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IMoveLeftOnLeave {
    
    
    
    Vector3 Offset {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ITransporterPlate {
    
    
    
    
    Vector3 MoveOffset {
        get;
        set;
    }
    
    Boolean IsOn {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IDissolvePlate {
    
    
    
    Boolean IsDissolved {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IYingYangPlate {
    
    
    
    bool IsDirty {
        get;
        set;
    }
    
    Int32[] TargetPlates {
        get;
        set;
    }
}

public interface ILevel {
    
    
    
    
    
    
    Int32 LevelNumber {
        get;
        set;
    }
    
    Int32 MaxXP {
        get;
        set;
    }
    
    Int32 MinimumMoves {
        get;
        set;
    }
    
    Int32 MovesTaken {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ILevelSpawnPoint {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface INotifyOnEnter {
    
    
    
    String Message {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IBasicGame {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IEnterLevelOnEnter {
    
    
    
    String SceneName {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ICubeSpawnPoint {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ISwitchOnWithXp {
    
    
    
    Int32 RequiredXp {
        get;
        set;
    }
    
    bool IsDirty {
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
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IWindow {
    
    
    
    FlipCubeWindow WindowType {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface ICloseWindowOnClick {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IZonesWindow {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IFriendsWindow {
    
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IPlayer {
    
    
    
    
    
    
    String Name {
        get;
        set;
    }
    
    Int32 XP {
        get;
        set;
    }
    
    Int32 Rank {
        get;
        set;
    }
    
    Int32 TotalFlips {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IActiveWithXp {
    
    
    
    Int32 RequiredXp {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IScoring {
    
    
    
    Int32 Score {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}

public interface IZone {
    
    
    
    
    String ZoneName {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
    
    Int32[] Levels {
        get;
        set;
    }
}

public interface ITutorialOnEnter {
    
    
    
    
    Int32 ArrowOver {
        get;
        set;
    }
    
    String Message {
        get;
        set;
    }
    
    bool IsDirty {
        get;
        set;
    }
}
