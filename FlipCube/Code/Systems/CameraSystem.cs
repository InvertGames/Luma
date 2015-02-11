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
    private Transform _goal;
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
            if (_goal != null)
            {
                var g = Game.ComponentSystem.GetAllComponents<GoalPlate>().FirstOrDefault();
                if (g != null)
                {
                    _goal = g.transform;
                }
                
                
                
            }
            if (_goal == null)
            {
                _goal = Following.transform;
            }
           
            _delta = (_goal.position - Following.transform.position) * 0.5f;
        }

        var between = Following.transform.position + (_delta * 0.2f);

        var rb = Following.rigidbody;
        if (Following != null && rb != null)
        {
            var velocityX = rb.velocity.x;
            var velocityY = rb.velocity.y;
            var velocityZ = rb.velocity.z;
            FollowCamera.transform.position = new Vector3(Mathf.SmoothDamp(FollowCamera.transform.position.x, between.x, ref velocityX, smoothTime),
                Mathf.SmoothDamp(FollowCamera.transform.position.y, between.y, ref velocityY, smoothTime),
                Mathf.SmoothDamp(FollowCamera.transform.position.z, between.z, ref velocityZ, smoothTime));
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
