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
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom)
        {
            yield return null;
        }
        SceneManager.LoadScene(0);
    }

    public void OnClick_ReloadGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(ReloadGame());
        }
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
