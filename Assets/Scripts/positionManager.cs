using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class positionManager : MonoBehaviour
{
    public vehicleCollisionController vcc;

    public int playerCurrentLap;
    int playerCurrentCheckpointCount;
    public int currentPosition;

    List<GameObject> tempPlayer;
    


    void Start()
    {
        vcc = GetComponent<vehicleCollisionController>();
        tempPlayer = vcc.cc.players.ToList();

        tempPlayer.Remove(tempPlayer.Find(x => x == gameObject));
        currentPosition = 5;

       
    }


    // Update is called once per frame
    void Update()
    {

            playerCurrentLap = GetComponent<vehicleCollisionController>().currentLap;
            playerCurrentCheckpointCount = GetComponent<vehicleCollisionController>().checkpointCount;



        foreach (GameObject player in tempPlayer) 
        {
            if (playerCurrentLap == player.GetComponent<vehicleCollisionController>().currentLap)
            {
                if (playerCurrentCheckpointCount == player.GetComponent<vehicleCollisionController>().checkpointCount)
                {
                    if (Vector3.Distance(transform.position, GetComponent<vehicleCollisionController>().cc.checkpoints[playerCurrentCheckpointCount].transform.position) > Vector3.Distance(player.transform.position, player.GetComponent<vehicleCollisionController>().cc.checkpoints[playerCurrentCheckpointCount].transform.position))
                    {
                        currentPosition--;
                    }
                    else
                        currentPosition++;
                }
                else if (playerCurrentCheckpointCount < player.GetComponent<vehicleCollisionController>().checkpointCount)
                    currentPosition++;
                else
                    currentPosition--;
            }
            else if (playerCurrentLap > player.GetComponent<vehicleCollisionController>().currentLap)
            {
                currentPosition--;
            }
            else 
            {
                currentPosition++;
            }
            
        }

    }

    

}

