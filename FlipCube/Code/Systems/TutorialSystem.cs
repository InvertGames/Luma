using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class TutorialSystem : TutorialSystemBase
{
    public GameObject _ArrowCanvas;
    public override void Initialize(IGame game)
    {
        base.Initialize(game);
        _ArrowCanvas.SetActive(false);
     
    }
    public bool IsMoving { get; set; }
    protected override void TutorialOnEnter(PlateCubeCollsion data, TutorialOnEnter tutorialonenter, Plate plate)
    {
        base.TutorialOnEnter(data, tutorialonenter, plate);
        _ArrowCanvas.GetComponent<RectTransform>().position = plate.transform.position + Vector3.up;
      
        _ArrowCanvas.SetActive(true);
     
        NotificationSystem.SignalDisplay(Game, new NotificationData()
        {
            Message = tutorialonenter.Message
        });
        IsMoving = true;
        MoveUp();
        Delay(5f, () =>
        {
            _ArrowCanvas.SetActive(false);
            IsMoving = false;
        });
    }

    public void MoveUp()
    {
        _ArrowCanvas.transform.positionTo(1f, Vector3.up, true).setOnCompleteHandler(tween =>
        {
            if (IsMoving)
            MoveDown();
        });
    }
    public void MoveDown()
    {
        _ArrowCanvas.transform.positionTo(1f, Vector3.down, true).setOnCompleteHandler(tween =>
        {
            if (IsMoving)
            MoveUp();
        });
    }
}
