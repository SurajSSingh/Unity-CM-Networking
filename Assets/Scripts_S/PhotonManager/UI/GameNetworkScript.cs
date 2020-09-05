using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameNetworkScript : MonoBehaviourPunCallbacks
{
    public int levelIndex;

    public void OnClick_LeaveGame()
    {
        StartCoroutine(LeaveGame());
    }

    IEnumerator LeaveGame()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
        {
            yield return null;
        }
        SceneManager.LoadScene(0);
    }

    public void OnClick_ReloadGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("RPC_Reload", RpcTarget.All);
        }
    }

    [PunRPC]
    public void RPC_Reload()
    {
        //StartCoroutine(ReloadGame());
        PhotonNetwork.LoadLevel(levelIndex);
    }

    IEnumerator ReloadGame()
    {
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom)
        {
            yield return null;
        }
        PhotonNetwork.LoadLevel(levelIndex);
    }
}
