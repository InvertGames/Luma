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


public interface IDamageable {
    
    
    Single Health {
        get;
        set;
    }
}

public interface ITargetable {
}

public interface ITargeter {
    
    
    Int32 Target {
        get;
        set;
    }
}
