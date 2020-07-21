using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winmanager : MonoBehaviour
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
}
