using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RoomInfo roomInfo { get; private set; }
    public GameObject GameLobby;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
        GameLobby.SetActive(true);
    }
}
