using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playerPositions : MonoBehaviour
{
   



    public loadPlayers lp;

    public List<GameObject> players;


    void Start()
    {
        



       

        players = GameObject.FindGameObjectsWithTag("player").ToList();


    }


    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < players.Count - 1; i++) 
        {
            for (int j = i + 1; j < players.Count; j++) 
            {
                if (players[i].GetComponent<vehicleCollisionController>().currentLap == players[j].GetComponent<vehicleCollisionController>().currentLap)
                {
                    if (players[i].GetComponent<vehicleCollisionController>().checkpointCount == players[j].GetComponent<vehicleCollisionController>().checkpointCount)
                    {
                        if (Vector3.Distance(players[i].transform.position, players[i].GetComponent<vehicleCollisionController>().cc.checkpoints[players[i].GetComponent<vehicleCollisionController>().checkpointCount + 1].transform.position) < Vector3.Distance(players[j].transform.position, players[j].GetComponent<vehicleCollisionController>().cc.checkpoints[players[j].GetComponent<vehicleCollisionController>().checkpointCount + 1].transform.position))
                        {


                            positionSwap(players, i, j);
                        }


                    }


                }
                

            }
        }
    }
        
        

    void positionSwap(List<GameObject> pi, int player, int otherPlayers)
    {
        GameObject tmp = pi[player];
        pi[player] = pi[otherPlayers];
        pi[otherPlayers] = tmp;
    }
}
