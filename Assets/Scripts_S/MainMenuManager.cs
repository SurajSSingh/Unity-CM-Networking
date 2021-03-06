﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenuManager : MonoBehaviour
{
    //public List<GameObject> gameLobbies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("name", "Unnamed");
        //foreach (GameObject lobby in gameLobbies)
        //{
        //    lobby.SetActive(false);
        //}
    }

    //public void OpenGameLobby(int gameID)
    //{
    //    if (gameID >= 0 && gameID < gameLobbies.Count)
    //    {
    //        gameLobbies[gameID].SetActive(true);
    //    }
        
    //}

    //public void CloseGameLobby(int gameID)
    //{
    //    if (gameID >= 0 && gameID < gameLobbies.Count)
    //    {
    //        gameLobbies[gameID].SetActive(false);
    //    }
    //}

    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        Debug.Log("New name: " + name);
        PhotonNetwork.NickName = name;
        PlayerPrefs.SetString("name", name);
    }

    public void QuitGame()
    {
        // Deletes name and other values when exiting the game
        PhotonNetwork.Disconnect();
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
