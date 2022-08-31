using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


public class raycast : MonoBehaviour
{
    private Transform theCam;
    public GameObject raycastCreate;
    public float focus;

    // private PlayerControls playerControls;
    void Start()
    {
        theCam=Camera.main.transform;
    }
    private void FixedUpdate()
    {
        // Debug.Log(Mouse.current.scroll.ReadValue());
        // Change focus based on scroll wheel
        if (Mouse.current.scroll.ReadValue().y > 0) {
            //Debug.Log(Mouse.current.scroll.ReadValue());
            focus += 0.1f;
        } else if (Mouse.current.scroll.ReadValue().y < 0) {
            //Debug.Log(Mouse.current.scroll.ReadValue());
            focus -= 0.1f;
        }
        focus = Mathf.Clamp(focus, 0.00f, 0.50f);

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;     
        // Does the ray intersect any objects excluding the player layer
        Vector3 direction= theCam.forward;
        Vector3 spread = Vector3.zero;
        spread += theCam.up * Random.Range(-1 * focus, focus);
        spread += theCam.right * Random.Range(-1 * focus, focus);
        if (Physics.Raycast(theCam.position, spread + direction, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(theCam.position, theCam.forward * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

            //Debug.Log(Mouse.current.scroll.ReadValue().normalized);
            Instantiate(raycastCreate, hit.point, raycastCreate.transform.rotation);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}