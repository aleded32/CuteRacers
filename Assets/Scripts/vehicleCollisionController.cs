using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleCollisionController : MonoBehaviour
{
    public int currentLap;
    public int checkpointCount = 0;
    public checkpointController cc;
    int tempCheckpoint;

    private void Start()
    {
        cc = GameObject.FindWithTag("checkpointController").GetComponent<checkpointController>();
    }


    private void OnTriggerExit(Collider other)
    {
        tempCheckpoint = checkpointCount;

        if (other.tag == "Checkpoint")
        {
            if (checkpointCount <= 0 && other.name != "start")
            {   
                checkpointCount++;
                

            }
            else if(checkpointCount > 0 && other.name != "start") 
            {
                for (int i = 0; i < tempCheckpoint; i++)
                {

                    
                    if (other.name == cc.checkpoints[i].name)
                    {
                        
                        Debug.Log("going wrong way");
                    }
                    else if(other.name != cc.checkpoints[i].name)
                    {

                        if (checkpointCount >= cc.checkpoints.Count)
                        {
                            currentLap++;
                            checkpointCount = 0;
                        }
                        else 
                        {
                            checkpointCount++;
                        }
                       
                        
                    }
                }
                tempCheckpoint = 0;
                
                
            }

            
        }
        
    }
}
