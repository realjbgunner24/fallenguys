using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject playerPrefab;
    // Start is called before the first frame update
 
   public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        playerPrefab = PhotonNetwork.Instantiate("OnlinePlayer",transform.position,transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(playerPrefab);
    }


   

}
