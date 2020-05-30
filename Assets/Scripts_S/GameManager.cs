using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    // This is for the quit the quit button
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
