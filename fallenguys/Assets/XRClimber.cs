using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using JetBrains.Annotations;
using System;
using UnityEngine.InputSystem;

public class XRClimber : MonoBehaviour
{
    private CharacterController character;
    public static ActionBasedController climbingHand;
    public static int delay;
    private ActionBasedContinuousMoveProvider continuousMovement;
    private Vector3 pos, velocity;
    private String controllerName;
    
  
    public InputActionProperty controllerProperty;

    void Start()
    {
        delay = 0;
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ActionBasedContinuousMoveProvider>();

    }

    void FixedUpdate()
    {
        //Debug.Log(controllerProperty.action.ReadValue<float>());

        if (climbingHand)
        {  
           
            if (delay >= 2 && climbingHand.name == controllerName) {
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
