using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject cam;

    float dist = 3.0f;
    public Rigidbody rb;


    void Start()
    {
        cam.transform.Rotate(25, 0, 0);
    }

    void Update()
    {
        playerCam();   
    }

    void playerCam() 
    {
        cam.transform.position = new Vector3(this.transform.position.x, 3, this.transform.position.z - dist);
        
        
    }
}
