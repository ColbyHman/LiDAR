using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform theCam;
    // Start is called before the first frame update
    void Start()
    {
        theCam=Camera.main.transform;
        transform.forward = theCam.forward;
    }

    // Update is called once per frame
//    void LateUpdate()
//    {
        
//    }
}
