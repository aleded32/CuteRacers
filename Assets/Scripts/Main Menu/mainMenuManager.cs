using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{

    public GameObject car;

    private void Start() 
    {
        
    }

    private void Update()
    {
        car.transform.Rotate(0, 10 * Time.deltaTime, 0);
    }

      
    

    public void start()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
