using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class positionManager : MonoBehaviour
{

    public int currentLap;
    public int currentPosition;
    playerPositions pp;

    private void Start()
    {
        pp = GameObject.FindWithTag("checkpointController").GetComponent<playerPositions>();
    }

    private void Update()
    {
        currentLap = pp.players.Find(x => x == gameObject).GetComponent<vehicleCollisionController>().currentLap;
        currentPosition = pp.players.FindIndex(x => x == gameObject) + 1;
    }
}



