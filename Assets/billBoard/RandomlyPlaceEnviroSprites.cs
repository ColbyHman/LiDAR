using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyPlaceEnviroSprites : MonoBehaviour
{
    public GameObject[] lidarPoints;

    public int copiesToMake;

    public float minDistance, maxDistance;

    public float height;

    public Camera cam;
    
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.transform.parent.GetComponent<Camera>();

        foreach(GameObject spr in lidarPoints)
        {
            SelectSpawnPoint(minDistance);

            spr.transform.position = spawnPoint;

            for(int i = 0; i < copiesToMake; i++)
            {
                SelectSpawnPoint(minDistance);

                Instantiate(spr, spawnPoint, spr.transform.rotation).transform.parent = transform;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSpawnPoint(float minDist)
    {
        float x = Random.Range(0, 1f);
        float y = Random.Range(0, 1f);
        float z = Random.Range(minDistance, maxDistance);
        // spawnPoint.y = height;

        spawnPoint = cam.ViewportToWorldPoint(new Vector3(x, y, z));
        spawnPoint = Vector3.ClampMagnitude(spawnPoint, 1f) * maxDistance;

        if(spawnPoint.magnitude < minDist)
        {
            SelectSpawnPoint(minDist);
        }
    }
}
