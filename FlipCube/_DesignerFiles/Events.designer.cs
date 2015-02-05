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


public class RollEventDataBase : object {
    
    private Single _Angle;
    
    private Vector3 _Center;
    
    private Vector3 _Axis;
    
    private Vector3 _CurrentPosition;
    
    private Quaternion _CurrentAngles;
    
    private Vector3 _Direction;
    
    private Int32 _EntityId;
    
    private Vector3 _FuturePosition;
    
    private Quaternion _FutureAngles;
    
    public Single Angle {
        get {
            return _Angle;
        }
        set {
            _Angle = value;
        }
    }
    
    public Vector3 Center {
        get {
            return _Center;
        }
        set {
            _Center = value;
        }
    }
    
    public Vector3 Axis {
        get {
            return _Axis;
        }
        set {
            _Axis = value;
        }
    }
    
    public Vector3 CurrentPosition {
        get {
            return _CurrentPosition;
        }
        set {
            _CurrentPosition = value;
        }
    }
    
    public Quaternion CurrentAngles {
        get {
            return _CurrentAngles;
        }
        set {
            _CurrentAngles = value;
        }
    }
    
    public Vector3 Direction {
        get {
            return _Direction;
        }
        set {
            _Direction = value;
        }
    }
    
    public Int32 EntityId {
        get {
            return _EntityId;
        }
        set {
            _EntityId = value;
        }
    }
    
    public Vector3 FuturePosition {
        get {
            return _FuturePosition;
        }
        set {
            _FuturePosition = value;
        }
    }
    
    public Quaternion FutureAngles {
        get {
            return _FutureAngles;
        }
        set {
            _FutureAngles = value;
        }
    }
}

public class MoveCubeDataBase : object {
    
    private Int32 _CubeId;
    
    private Vector3 _Position;
    
    public Int32 CubeId {
        get {
            return _CubeId;
        }
        set {
            _CubeId = value;
        }
    }
    
    public Vector3 Position {
        get {
            return _Position;
        }
        set {
            _Position = value;
        }
    }
}

public class PlateCubeCollsionBase : object {
    
    private Int32 _CubeId;
    
    private Int32 _PlateId;
    
    public Int32 CubeId {
        get {
            return _CubeId;
        }
        set {
            _CubeId = value;
        }
    }
    
    public Int32 PlateId {
        get {
            return _PlateId;
        }
        set {
            _PlateId = value;
        }
    }
}

public class NotificationDataBase : object {
    
    private String _Message;
    
    public String Message {
        get {
            return _Message;
        }
        set {
            _Message = value;
        }
    }
}

public class PlayerEventDataBase : object {
    
    private Player _PlayerData;
    
    public Player PlayerData {
        get {
            return _PlayerData;
        }
        set {
            _PlayerData = value;
        }
    }
}
