using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using JetBrains.Annotations;

public class XRClimbable : XRBaseInteractable
{
    public AudioSource audio;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;
     
        //base.OnSelectEntered(args);

        if (interactor is XRDirectInteractor)
        {
            XRClimber.climbingHand = interactor.GetComponent<ActionBasedController>();
            audio.Play();
        }
    }


    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        XRBaseInteractor interactor = args.interactor;
      

        if (XRClimber.climbingHand && XRClimber.climbingHand.name == interactor.name)
        {
            XRClimber.climbingHand = null;
            audio.Stop();
        }
    }



    protected override void OnSelectExited(SelectExitEventArgs args)
    { 
        base.OnSelectExited(args);
        XRBaseInteractor interactor = args.interactor;
       

        if (XRClimber.climbingHand && XRClimber.climbingHand.name == interactor.name)
        {
            XRClimber.climbingHand = null;
            audio.Stop();
        }
    }

}
