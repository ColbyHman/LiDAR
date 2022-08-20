using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    private Transform theCam;
    public GameObject raycastCreate;
    public float focus;
    void Start()
    {
        theCam=Camera.main.transform;
        
    }
    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(theCam.position, theCam.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(theCam.position, theCam.forward * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            Instantiate(raycastCreate, hit.point, raycastCreate.transform.rotation);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
