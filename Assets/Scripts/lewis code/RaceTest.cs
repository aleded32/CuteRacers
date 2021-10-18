using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTest : MonoBehaviour
{
    public static RaceTest instance;

    public Checkpoints[] allCheckpoints;

    public int totalLaps;

    public VehicleMovement playerCar;
    public List<VehicleMovement> allAiCars = new List<VehicleMovement>();
    public List<VehicleMovement> allPlayerCars = new List<VehicleMovement>();
    public int playerPosition;
    public float timeBetweenPosCheck = .2f;
    private float PosCheckCounter;

    public float aiDefaultSpeed = 30f, playerDefaultSpeed = 30f, rubberBandSpeedMod = 3.5f, rubberBandAccel = .5f;

    public bool isStarting;
    public float timeBetweenStartCount = 1f;
    private float startCounter;
    public int countdownCurrent = 3;

    public int playerStartPosition, aiNumberToSpawn, PlayerToSpawn;
    public Transform[] startPoints;
    public List<VehicleMovement> carsToSpawn = new List<VehicleMovement>();

    public bool raceCompleted;

    public string raceCompleteScene;
    public string restartScene;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allCheckpoints.Length; i++)
        {
            allCheckpoints[i].checkpointNumber = i;
        }

       

       // UI_Manager.instance.countdownText.text = countdownCurrent + "!";
       
        playerStartPosition = Random.Range(0, aiNumberToSpawn + 1);
        playerStartPosition = Random.Range(0, PlayerToSpawn + 1);

        playerCar.transform.position = startPoints[playerStartPosition].position;
        playerCar.theRB.transform.position = startPoints[playerStartPosition].position;

        for (int i = 0; i < aiNumberToSpawn + 1; i++)
        {
            if (i != playerStartPosition)
            {
                int selectedCar = Random.Range(0, carsToSpawn.Count);

                allAiCars.Add(Instantiate(carsToSpawn[selectedCar], startPoints[i].position, startPoints[i].rotation));

                if (carsToSpawn.Count >= aiNumberToSpawn - i )
                {
                    carsToSpawn.RemoveAt(selectedCar);
                }
            }
        }

        for (int i = 0; i < PlayerToSpawn + 1; i++)
        {
            if (i != playerStartPosition)
            {
                int selectedCar = Random.Range(0, carsToSpawn.Count);

                allPlayerCars.Add(Instantiate(carsToSpawn[selectedCar], startPoints[i].position, startPoints[i].rotation));

                if (carsToSpawn.Count >= PlayerToSpawn - i)
                {
                    carsToSpawn.RemoveAt(selectedCar);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Countdown delay before the race
        if (isStarting)
        {
            startCounter -= Time.deltaTime;
            if (startCounter <= 0)
            {
                countdownCurrent--;
                startCounter = timeBetweenStartCount;

               // UI_Manager.instance.countdownText.text = countdownCurrent + "!";

                if (countdownCurrent == 0)
                {
                    isStarting = false;

                    //UI_Manager.instance.countdownText.gameObject.SetActive(false);
                   // UI_Manager.instance.goText.gameObject.SetActive(true);
                }
            }
        }
        else
        {


            //Updating the player position in the race.
            PosCheckCounter -= Time.deltaTime;
            if (PosCheckCounter <= 0)
            {



                playerPosition = 1;

                foreach (VehicleMovement aiCar in allAiCars)
                {
                    if (aiCar.currentLap > playerCar.currentLap)
                    {
                        playerPosition++;
                    }
                    else if (aiCar.currentLap == playerCar.currentLap)
                    {
                        if (aiCar.nextCheckpoint > playerCar.nextCheckpoint)
                        {
                            playerPosition++;
                        }

                        else if (aiCar.nextCheckpoint == playerCar.nextCheckpoint)
                        {
                            if (Vector3.Distance(aiCar.transform.position, allCheckpoints[aiCar.nextCheckpoint].transform.position) < Vector3.Distance(playerCar.transform.position, allCheckpoints[aiCar.nextCheckpoint].transform.position))
                            {
                                playerPosition++;
                            }
                        }
                    }
                }

                foreach (VehicleMovement playerCars in allPlayerCars)
                {
                    if (playerCars.currentLap > playerCar.currentLap)
                    {
                        playerPosition++;
                    }
                    else if (playerCars.currentLap == playerCar.currentLap)
                    {
                        if (playerCars.nextCheckpoint > playerCar.nextCheckpoint)
                        {
                            playerPosition++;
                        }

                        else if (playerCars.nextCheckpoint == playerCar.nextCheckpoint)
                        {
                            if (Vector3.Distance(playerCars.transform.position, allCheckpoints[playerCars.nextCheckpoint].transform.position) < Vector3.Distance(playerCar.transform.position, allCheckpoints[playerCars.nextCheckpoint].transform.position))
                            {
                                playerPosition++;
                            }
                        }
                    }
                }
                PosCheckCounter = timeBetweenPosCheck;

               UI_Manager.instance.positionText.text = playerPosition + "/" + (allAiCars.Count + 1);
            }

            //Rubberband
            if (playerPosition == 1)
            {
                foreach (VehicleMovement aiCar in allAiCars)
                {
                    aiCar.maxSpeed = Mathf.MoveTowards(aiCar.maxSpeed, aiDefaultSpeed + rubberBandSpeedMod, rubberBandAccel * Time.deltaTime);
                }

                foreach (VehicleMovement playerCars in allPlayerCars)
                {
                    playerCars.maxSpeed = Mathf.MoveTowards(playerCars.maxSpeed, playerDefaultSpeed + rubberBandSpeedMod, rubberBandAccel * Time.deltaTime);
                }

                playerCar.maxSpeed = Mathf.MoveTowards(playerCar.maxSpeed, playerDefaultSpeed - rubberBandSpeedMod, rubberBandAccel * Time.deltaTime);
            }
            else
            {
                foreach (VehicleMovement playerCars in allPlayerCars)
                {
                    playerCars.maxSpeed = Mathf.MoveTowards(playerCars.maxSpeed, playerDefaultSpeed - (rubberBandSpeedMod * ((float)playerPosition / ((float)allPlayerCars.Count + 1))), rubberBandAccel * Time.deltaTime);
                }

                playerCar.maxSpeed = Mathf.MoveTowards(playerCar.maxSpeed, playerDefaultSpeed + (rubberBandSpeedMod * ((float)playerPosition / ((float)allPlayerCars.Count + 1))), rubberBandAccel * Time.deltaTime);
            }
        }
    }

    public void FinishRace()
    {
        raceCompleted = true;

        switch (playerPosition)
        {
            case 1:
               // UI_Manager.instance.raceResultText.text = "You Finished 1st";


                break;

            case 2:
               // UI_Manager.instance.raceResultText.text = "You Finished 2nd";


                break;

            case 3:
               // UI_Manager.instance.raceResultText.text = "You Finished 3rd";


                break;

            default:

               // UI_Manager.instance.raceResultText.text = "You Finished " + playerPosition + "th";

                break;
        }
       // UI_Manager.instance.resultScreen.SetActive(true);
    }
    public void ExitRace()
    {
       // SceneManager.LoadScene(raceCompleteScene);
    }
    public void RestartRace()
    {
        if (raceCompleted = true && Input.GetButton("Restart"))
        {
            //SceneManager.LoadScene(restartScene);
        }
    }

    public void QuitGame()
    {
        if (raceCompleted = true && Input.GetButton("Quit"))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
