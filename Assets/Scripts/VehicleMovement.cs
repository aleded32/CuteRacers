using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleMovement : MonoBehaviour
{
    float accel = 9f;
    float decel = 3f;
    float maxSpeed = 12f;
    float maxReverseSpeed = -4f;
    float steerAngle;
    float grip = 1.2f;

   
    
    public Rigidbody rb;

    void Start()
    {
        
    }
    
    void Update()
    {
        drive();
        steer();
        
    }


    void drive()
    {
        if (Gamepad.current.rightTrigger.ReadValue() > 0)
        {
            if (rb.velocity.z >= maxSpeed)
            {
                rb.velocity = new Vector3(0,0,maxSpeed);
            }
            else
            {
                rb.velocity += transform.forward * accel * Gamepad.current.rightTrigger.ReadValue() * Time.deltaTime;
            }

            //rb.AddForceAtPosition(rb.velocity * rb.mass * grip, transform.position);
           
        }
        
        if (Gamepad.current.leftTrigger.ReadValue() > 0) 
        {
            if (rb.velocity.z <= maxReverseSpeed)
            {
                rb.velocity = new Vector3(0, 0, maxReverseSpeed);
                
            }
            else
            {
                rb.velocity += transform.forward * -decel * Gamepad.current.leftTrigger.ReadValue() * Time.deltaTime;
            }

            

        }
        
    }

    void steer() 
    {

        if (Gamepad.current.leftStick.ReadValue().x < 0)
        {
            steerAngle += Gamepad.current.leftStick.ReadValue().x * 75 * Time.deltaTime;
            rb.rotation = Quaternion.Euler(0, steerAngle, 0);
        }

        else if (Gamepad.current.leftStick.ReadValue().x > 0)
        {
            steerAngle += Gamepad.current.leftStick.ReadValue().x * 75 * Time.deltaTime;
            rb.rotation = Quaternion.Euler(0, steerAngle, 0);
        }
    }
}
