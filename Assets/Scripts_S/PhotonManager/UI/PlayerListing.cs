using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class PlayerListing : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Player player;

    public void SetPlayerInfo(Player player)
    {
        this.player = player;
        text.text = player.NickName;
    }
}
