using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
public class OnlinePlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;

    private GameObject body;


    public Transform righthand;

    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        body = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine){
            mapPosition(head,XRNode.Head);
            mapPosition(leftHand, XRNode.LeftHand);
            mapPosition(righthand, XRNode.RightHand);
            movePlayer();
            
        }
    }

    void mapPosition(Transform target, XRNode node){
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
         InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
        
        target.position = position;
        target.rotation = rotation;
    }

    void movePlayer()
    {
        if (body)
        {
            transform.position = body.transform.position;
            transform.rotation = body.transform.rotation;
            Debug.Log("Found");
        }
        else
        {
            Debug.Log("XROrigin Not Found");
        }
    }
}
