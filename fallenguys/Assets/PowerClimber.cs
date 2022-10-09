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
    private Vector3 pos, velocity;
    private String controllerName;
   

    public  ActionBasedController leftClimbingHand;
    public  ActionBasedController rightClimbingHand;
    public InputActionProperty leftControllerProperty; 
    public InputActionProperty rightControllerProperty;

    void Start()
    {
        delay = 0;
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ActionBasedContinuousMoveProvider>();

    }

    void FixedUpdate()
    {
        //Debug.Log(controllerProperty.action.ReadValue<float>());


        if (leftControllerProperty.action.ReadValue<float>() == 1)
        {
            climbingHand = leftClimbingHand;
        }else if (rightControllerProperty.action.ReadValue<float>() == 1)
        {
             climbingHand = rightClimbingHand;
        }else
        {
            climbingHand = null;
        }

       


        if (climbingHand)
        {

            if (delay >= 2 && climbingHand.name == controllerName)
            {
                velocity = (climbingHand.currentControllerState.position - pos) / Time.fixedDeltaTime;
                pos = climbingHand.currentControllerState.position;

                continuousMovement.enabled = false;
                Climb();
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
            delay = 0;
            continuousMovement.enabled = true;
        }
    }

    void Climb()
    {
        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }


}
