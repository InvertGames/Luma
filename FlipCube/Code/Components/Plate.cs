using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;

[ExecuteInEditMode]
public partial class Plate : PlateBase {
    public void ToolbarAddQuick(ToolbarArgs args)
    {
        switch (args.LastKeyPressed)
        {
            case KeyCode.A:
            case KeyCode.D:
            case KeyCode.S:
            case KeyCode.W:
                args.ShouldAdd = true;
                break;
        }
    }
    public void ToolbarAdd(ToolbarArgs args)
    {
        if (args.IsReplacement) return;
        if (args.LastKeyPressed == KeyCode.A)
        {
            this.transform.position = (args.SelectedObject.transform.position + Vector3.left);
            
        }
        else if (args.LastKeyPressed == KeyCode.D)
        {
            this.transform.position = (args.SelectedObject.transform.position + Vector3.right);
        }
        else if (args.LastKeyPressed == KeyCode.S)
        {
            this.transform.position = (args.SelectedObject.transform.position + Vector3.back);
        }
        else
        {
            this.transform.position = (args.SelectedObject.transform.position + Vector3.forward);
        }

       

    }
}
