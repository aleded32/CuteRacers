using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public positionManager pm;
    public Text[] gameUI;

    void Start()
    {
        gameUI[0].text = pm.playerCurrentLap + " / " + 3;
        gameUI[1].text = pm.currentPosition + " / " + 5;

    }

    // Update is called once per frame
    void Update()
    {
        gameUI[0].text = pm.playerCurrentLap + " / " + 3;
        gameUI[1].text = pm.currentPosition + " / " + 5;
    }
}
