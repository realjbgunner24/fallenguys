using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AirRolling : MonoBehaviour
{   
    private ActionBasedContinuousMoveProvider continuousMovement;
    private CharacterController character;
    public ActionBasedController leftClimbingHand;
    public ActionBasedController rightClimbingHand;
    public InputActionProperty leftControllerProperty;
    public InputActionProperty rightControllerProperty;
    public static ActionBasedController climbingHand;
    public static int delay;
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ActionBasedContinuousMoveProvider>();
    }

}
