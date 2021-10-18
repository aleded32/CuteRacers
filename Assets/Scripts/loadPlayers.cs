using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class loadPlayers : MonoBehaviour
{

    public GameObject playerPreFab;

    public List<GameObject> playerVehicles;

    List<PlayerInput> players = new List<PlayerInput>();

    void Awake()
    {

        Debug.Log(Gamepad.all.Count);
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            if (i == 0)
            {
                players.Add(PlayerInput.Instantiate(playerVehicles[0], pairWithDevice: Gamepad.all[i]));
            }
            else if(i == 1)
            {
                players.Add(PlayerInput.Instantiate(playerVehicles[1], pairWithDevice: Gamepad.all[i]));
            }

            players[i].transform.position = new Vector3((i+1) * 1.5f, 3, 0);
           

        }
       

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
