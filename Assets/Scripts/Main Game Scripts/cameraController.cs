using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject camLook;

    float dist = 9.0f;
    


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        playerCam();   
    }

    void playerCam() 
    {
       transform.position = Vector3.Lerp(camLook.transform.position, player.transform.position, 1 * Time.deltaTime);
        transform.LookAt(player.transform.position);
               
    }
}
