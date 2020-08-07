using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveRoomMenu : MonoBehaviour
{
    public GameObject gameLobby;
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        gameLobby.SetActive(false);
    }
}
