using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class CameraSystem : CameraSystemBase
{
    public Transform FollowCamera;
    public float smoothTime;
    private GoalPlate _goal;
    private Vector3 _delta;

    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
        if (FollowCamera == null)
            FollowCamera = Camera.main.transform;
      
        
    }

    public override void Update()
    {
        base.Update();
        //if (Following == null) return;
        if (Following == null) return;
        if (_goal == null)
        {
            _goal = Game.ComponentSystem.GetAllComponents<GoalPlate>().FirstOrDefault();
            _delta = (_goal.transform.position - Following.transform.position) * 0.5f;
        }
        //FollowCamera.transform.position  = Following.transform.position + (Vector3.back * Following.Distance) + (Vector3.up * Following.Distance);
        //FollowCamera.transform.LookAt(Following.transform);

      
        //var delta = Vector3.forward;

        var between = Following.transform.position + (_delta * 0.2f);

        if (Following != null)
        {
            var velocityX = Following.transform.rigidbody.velocity.x;
            var velocityY = Following.transform.rigidbody.velocity.z;
            FollowCamera.transform.position = new Vector3(Mathf.SmoothDamp(FollowCamera.transform.position.x, between.x, ref velocityX, smoothTime),
                FollowCamera.transform.position.y,
                Mathf.SmoothDamp(FollowCamera.transform.position.z, between.z, ref velocityY, smoothTime));
        }
    }

    protected override void Selected(Invert.ECS.IEvent e) {
        base.Selected(e);
        OnSelection(e);
    }
    
    protected override void OnSelection(EntityEventData data, FollowOnSelection entityid) {
        base.OnSelection(data, entityid);
        Following = entityid;
        

    }

    public FollowOnSelection Following { get; set; }

    protected override void OnSelection(Invert.ECS.IEvent e) {
        base.OnSelection(e);
    }
}
