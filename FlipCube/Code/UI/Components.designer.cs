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


public class WindowBase : Invert.ECS.Unity.UnityComponent {
    
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

[UnityEngine.AddComponentMenu("UI/Window")]
public partial class Window {
}

public class ZonesWindowBase : Invert.ECS.Unity.UnityComponent {
}

[UnityEngine.AddComponentMenu("UI/ZonesWindow")]
public partial class ZonesWindow {
}

public class FriendsWindowBase : Invert.ECS.Unity.UnityComponent {
}

[UnityEngine.AddComponentMenu("UI/FriendsWindow")]
public partial class FriendsWindow {
}

public class ToggleWindowOnClickBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    private Int32 _WindowId;
    
    public virtual Int32 WindowId {
        get {
            return _WindowId;
        }
        set {
            _WindowId = value;
        }
    }
}

[UnityEngine.AddComponentMenu("UI/ToggleWindowOnClick")]
public partial class ToggleWindowOnClick {
}

public class CloseWindowOnClickBase : Invert.ECS.Unity.UnityComponent {
    
    [UnityEngine.SerializeField()]
    private Int32 _WindowId;
    
    public virtual Int32 WindowId {
        get {
            return _WindowId;
        }
        set {
            _WindowId = value;
        }
    }
}

[UnityEngine.AddComponentMenu("UI/CloseWindowOnClick")]
public partial class CloseWindowOnClick {
}
