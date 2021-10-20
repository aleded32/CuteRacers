using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleCollisionController : MonoBehaviour
{
    public int currentLap;
    public int checkpointCount;
    public checkpointController cc;
    
    
    public List<GameObject> checkpointsPassed;

    private void Start()
    {
        cc = GameObject.FindWithTag("checkpointController").GetComponent<checkpointController>();
        checkpointsPassed = new List<GameObject>();
        checkpointCount = checkpointsPassed.Count;
    }

    private void Update()
    {
        checkpointCount = checkpointsPassed.Count;

        if (checkpointCount > cc.checkpoints.Count - 1)
        {
            currentLap++;
            checkpointsPassed.Clear();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.tag == "Checkpoint")
        {

            if (checkpointsPassed.Count <= 0 && other.name != "start")
            {
                checkpointsPassed.Add(other.gameObject);
            }
            else if (!checkpointsPassed.Contains(other.gameObject)) 
            {
                checkpointsPassed.Add(other.gameObject);
            }
            
            
                
               
                
            

            
        }
        
    }
}
