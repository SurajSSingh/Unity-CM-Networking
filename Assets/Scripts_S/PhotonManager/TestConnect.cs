using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class TestConnect : MonoBehaviourPunCallbacks
{
    public GameSettings gs;
    public TextMeshProUGUI placeholderText;
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Connecting to Server.");
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = gs.gameVersion;
            PhotonNetwork.NickName = gs.nickName + Random.Range(10, 99).ToString();
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server.");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        placeholderText.text = PhotonNetwork.LocalPlayer.NickName;
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected to Server for: " + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }
}
