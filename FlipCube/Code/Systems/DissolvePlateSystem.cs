using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using Invert.ECS.Unity;
using UnityEngine;


public class DissolvePlateSystem : DissolvePlateSystemBase
{
    public GameObject DissolvePlatePrefab;
    protected override void OnDissolve(PlateCubeCollsion data, DissolvePlate dissolveplate)
    {
        base.OnDissolve(data, dissolveplate);
        StartCoroutine(Break(dissolveplate));

    }

    protected override void OnReset(EntityEventData data)
    {
        base.OnReset(data);
        foreach (var item in DissolvePlateManager.Components.ToArray())
        {
            if (!item.IsDissolved) continue;
            var entityId = item.EntityId;
            var newPlate = Instantiate(DissolvePlatePrefab) as GameObject;
            var entityComponent = newPlate.GetComponent<EntityComponent>();
            entityComponent.SetEntityId(entityId);
            newPlate.transform.parent = item.transform.parent;
            newPlate.transform.position = item.transform.position;
            DestroyImmediate(item.gameObject);
        }

    }

    public IEnumerator Break(DissolvePlate dissolveplate)
    {
        dissolveplate.IsDissolved = true;
        dissolveplate.GetComponent<Collider>().enabled = false;
        var rbs = dissolveplate.transform.GetChild(0).GetComponentsInChildren<Rigidbody>();
        var len = rbs.Length / 2;
        for (int index = 0; index < len; index++)
        {
            var rb = rbs[index];
            rb.collider.enabled = true;
            rb.useGravity = true;
            rb.AddExplosionForce(1f, rb.transform.position, 0.1f);
            rb.transform.parent = null;
            //yield return new WaitForSeconds(0.05f);
            Destroy(rb.gameObject, 2f);
            var rb2 = rbs[len + index];
            rb2.collider.enabled = true;
            rb2.useGravity = true;
            rb2.AddExplosionForce(1f, rb.transform.position, 0.1f);
            rb2.transform.parent = null;
            yield return new WaitForSeconds(0.05f);
            
        }
   

    }
}
