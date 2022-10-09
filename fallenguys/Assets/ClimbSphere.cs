using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbSphere : XRClimbable
{
    

 Transform _object;

    public Transform Object
    {
        get { return _object; }
        set { _object = value; }
    }




    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        XRBaseInteractor interactor = args.interactor;

        //base.OnSelectEntered(args);

        if (interactor is XRDirectInteractor)
        {
            PowerClimber.climbingHand = interactor.GetComponent<ActionBasedController>();

        }
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {

    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        XRBaseInteractor interactor = args.interactor;


        if (XRClimber.climbingHand && XRClimber.climbingHand.name == interactor.name)
        {
            PowerClimber.climbingHand = null;

        }
    }
}
