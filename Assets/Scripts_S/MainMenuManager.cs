﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> gameLobbies = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("name", "Unnamed");
        foreach (GameObject lobby in gameLobbies)
        {
            lobby.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenGameLobby(int gameID)
    {
        if (gameID >= 0 && gameID < gameLobbies.Count)
        {
            gameLobbies[gameID].SetActive(true);
        }
    }

    public void CloseGameLobby(int gameID)
    {
        if (gameID >= 0 && gameID < gameLobbies.Count)
        {
            gameLobbies[gameID].SetActive(false);
        }
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = name;
        PlayerPrefs.SetString("name", name);
    }

    public void QuitGame()
    {
        // Deletes name and other values when exiting the game
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
