using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PowerClimber : MonoBehaviour
{
    private CharacterController character;

    public static ActionBasedController climbingHand;
    public static int delay;
    private ActionBasedContinuousMoveProvider continuousMovement;
    private Vector3 pos, velocity,prevpos;
    private double speed,distance;
    private String controllerName;


    public ActionBasedController leftClimbingHand;
    public ActionBasedController rightClimbingHand;
    public InputActionProperty leftControllerProperty;
    public InputActionProperty rightControllerProperty;

    void Start()
    {
        delay = 0;
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ActionBasedContinuousMoveProvider>();
        speed = 0;
    }

    void FixedUpdate()
    {
        //Debug.Log(controllerProperty.action.ReadValue<float>());
       


        prevpos = pos;

        if (leftControllerProperty.action.ReadValue<float>() == 1)
        {
            climbingHand = leftClimbingHand;
            continuousMovement.enabled = false;
        } else if (rightControllerProperty.action.ReadValue<float>() == 1)
        {
            climbingHand = rightClimbingHand;
            continuousMovement.enabled = false;
        } else
        {
            continuousMovement.enabled = true;
            climbingHand = null;
        }

        
        if (Movement())
        {
            
        }
        speed += distance;
        speed -= 0.01;
        if (speed <= 0)
        {
            speed = 0;
            float _speed = (float)speed;
            Vector3 _velocity = velocity;
            _velocity.y = 0;
            character.Move(transform.rotation * -_velocity * Time.deltaTime/5);
        }
        else if (speed > 0 && speed <= 0.2)
        {
             float _speed = (float)speed;
            Vector3 _velocity = velocity;
            _velocity.y = 0;
            character.Move(transform.rotation * -_velocity * _speed/5);
        }else if (speed > 0.2)
        {
            speed = 0.2;
            float _speed = (float)speed;
            Vector3 _velocity = velocity;
            _velocity.y = 0;
            character.Move(transform.rotation * -_velocity * _speed/5);
        }
        else
        {
            character.Move(Vector3.zero);
        }
       
       
    }

    void Climb()
    { 

    }

    bool Movement() {
     
       
        if (climbingHand)
        {
          
             
            if (delay >= 2 && climbingHand.name == controllerName)
            {
                float dx = climbingHand.currentControllerState.position.x - pos.x;
             float dy = climbingHand.currentControllerState.position.z - pos.z;
             distance = Math.Sqrt(dx * dx + dy * dy);
                velocity = (climbingHand.currentControllerState.position - pos) / Time.fixedDeltaTime;
                
                pos = climbingHand.currentControllerState.position;

                continuousMovement.enabled = false;
              
                return true;
            }
            else
            {
                controllerName = climbingHand.name;
                pos = climbingHand.currentControllerState.position;

                delay++;

            }
        }
        else
        {
            distance = 0;
            delay = 0;
            continuousMovement.enabled = true; 
           
        }
        return false;
    }


}
