using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class ControllerVelocity : MonoBehaviour
{
    InputDevice LeftControllerDevice;
    InputDevice RightControllerDevice;
    public Vector3 LeftControllerVelocity;
    public Vector3 RightControllerVelocity;
    void Start()
    {
        LeftControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        RightControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
    void Update()
    {
        UpdateInput();
    }
    void UpdateInput()
    {
        LeftControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out LeftControllerVelocity);
        RightControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out RightControllerVelocity);
    }

}
