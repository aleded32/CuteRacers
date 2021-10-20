using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleMovement : MonoBehaviour
{
    float accel = 25f;
    float decel = 20f;
    public float maxSpeed = 50f;
    float maxReverseSpeed = -15f;
    float steerAngle;
    float grip = 2f;
    bool isForward = false;
    bool isReverse = false;

    public int nextCheckpoint;
    public int currentLap;

    public float lapTime, bestLapTime;

    public float throttleInput, brakeInput;
    Vector2 moveInput;
    public Rigidbody theRB;




    void Awake()
    {

        theRB = GetComponent<Rigidbody>();



    }

    void Start()
    {
     
    }


    void FixedUpdate()
    {

        drive();
        steer();
        

       


    }

    void OnThrottle(InputValue value)
    {
        throttleInput = value.Get<float>();


    }

    void OnBrake(InputValue value)
    {
        brakeInput = value.Get<float>();

    }

    void OnTurn(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }


    void drive()
    {
        if (throttleInput > 0)
        {

            isForward = true;
            if (theRB.velocity.z >= maxSpeed)
            {
                theRB.velocity = new Vector3(0, 0, maxSpeed);
            }
            else
            {
                theRB.velocity += transform.forward * accel * throttleInput * Time.deltaTime;
            }

            //theRB.AddForceAtPosition(theRB.velocity * theRB.mass * grip, transform.position);

        }
        else
        {
            isForward = false;
        }

        if (brakeInput > 0)
        {
            isReverse = true;

            if (theRB.velocity.z <= maxReverseSpeed)
            {
                theRB.velocity = new Vector3(0, 0, maxReverseSpeed);

            }
            else
            {
                theRB.velocity += transform.forward * -decel * brakeInput * Time.deltaTime;
            }



        }
        else
        {
            isReverse = false;
        }

    }

    void steer()
    {
        if (throttleInput < 1 || brakeInput < 1)
        {

            if (moveInput.x < 0)
            {
                if (isForward)
                {
                    steerAngle += moveInput.x * 60 * throttleInput * Time.deltaTime;
                }
                else if (isReverse)
                {
                    steerAngle -= moveInput.x * 60 * brakeInput * Time.deltaTime;
                }

                theRB.rotation = Quaternion.Euler(0, steerAngle, 0);
            }

            else if (moveInput.x > 0)
            {

                if (isForward)
                {
                    steerAngle += moveInput.x * 60 * throttleInput * Time.deltaTime;
                }
                else if (isReverse)
                {
                    steerAngle -= moveInput.x * 60 * brakeInput * Time.deltaTime;
                }
                theRB.rotation = Quaternion.Euler(0, steerAngle, 0);
            }
            else if (throttleInput > 0 && throttleInput < 1 && brakeInput > 0 && brakeInput < 1)
            {

                if (isForward)
                {
                    steerAngle += moveInput.x * 60 * throttleInput * Time.deltaTime;
                }
                else if (isReverse)
                {
                    steerAngle += moveInput.x * 60 * brakeInput * Time.deltaTime;
                }
            }
        }

        
    }
    

    
}
