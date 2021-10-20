using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointController : MonoBehaviour
{

    int totalLaps = 3;
    int startLap = 1;
    


    public List<GameObject> checkpoints;
    public GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("player");

        foreach (GameObject player in players) 
        {
            player.GetComponent<vehicleCollisionController>().currentLap = startLap;
        }
    }

    
    void Update()
    {
        for(int i = 0; i < players.Length; i++)
            Debug.Log(i + "  " +  "checkPoint count " + players[i].GetComponent<vehicleCollisionController>().checkpointCount + " currentLap " + players[i].GetComponent<vehicleCollisionController>().currentLap);
    }



}
