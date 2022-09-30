using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRClimbable : XRSimpleInteractable
{
   
    // Start is called before the first frame update
  

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        IXRSelectInteractor interactor = args.interactorObject;
        base.OnSelectEntered(args);
        Debug.Log("Eneter");
        if (interactor is XRDirectInteractor)
        {
            Debug.Log("Entered");
            //dosum
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        IXRSelectInteractor interactor = args.interactorObject;
        base.OnSelectExited(args);
        Debug.Log("Works");
        if (interactor is XRDirectInteractor /*&& what else    */)
        {
            Debug.Log("Exited");
            //dosum
        }
    }
}
