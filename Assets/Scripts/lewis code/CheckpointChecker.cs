using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChecker : MonoBehaviour
{
    public VehicleMovement player;
    private void OnTriggerEnter(Collider other)
    {
       /* if (other.tag == "Checkpoint")
        {
           // player.CheckpointHit(other.GetComponent<Checkpoints>().checkpointNumber);
        }*/
    }
}
