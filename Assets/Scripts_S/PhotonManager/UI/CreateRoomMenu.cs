using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    public string roomName = "Game";

    public GameObject GameLobby;

    private bool createdRoom = false;

    public void OnClick_CreateRoom(int numOfPlayers)
    {

        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("Not Connected to Server");
            return;
        }

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)numOfPlayers;
        createdRoom = true;
        PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
        
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Create Room Successfully.",this);
        if (createdRoom)
        {
            GameLobby.SetActive(true);
        }
        createdRoom = false;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create Room Failed." + message, this);
        createdRoom = false;
    }


}
