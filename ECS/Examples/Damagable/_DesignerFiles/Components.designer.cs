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


public class DamageableBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    private Single _Health;
    
    public virtual Single Health {
        get {
            return _Health;
        }
        set {
            _Health = value;
        }
    }
}

public class TargetableBase : Invert.ECS.Unity.UnityComponent {
}

public class TargeterBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    private Int32 _Target;
    
    public virtual Int32 Target {
        get {
            return _Target;
        }
        set {
            _Target = value;
        }
    }
}
