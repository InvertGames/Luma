using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;

[ExecuteInEditMode]
public partial class Cube : CubeBase
{

    public void ToolbarAdd(ToolbarArgs args)
    {
        this.transform.position = args.SelectedObject.transform.position + new Vector3(0f,1f,0f);
    }
}
