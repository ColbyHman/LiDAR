using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideEnvironment : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] Environment;
    public Boolean hide;
    void Start()
    {
        if (hide)
        {
            //MeshRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
