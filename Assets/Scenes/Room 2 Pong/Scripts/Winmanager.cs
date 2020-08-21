using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Winmanager : MonoBehaviourPunCallbacks
{
    public GameObject winScreen;
    public GameObject leftWinner;
    public GameObject rightWinner;



    void Start()
    {
        winScreen.SetActive(false);
        leftWinner.SetActive(false);
        rightWinner.SetActive(false);
    }

    public void WinGame(bool leftWin)
    {
        winScreen.SetActive(true);
        if (leftWin)
        {
            leftWinner.SetActive(true);
        }
        else
        {
            rightWinner.SetActive(true);
        }
        
    }

    public void BackToMenu()
    {
        PhotonNetwork.LeaveRoom(true);
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
