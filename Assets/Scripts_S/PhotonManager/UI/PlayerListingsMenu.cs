using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    public Transform content;
    public PlayerListing playerListingPrefab;
    public GameObject GameLobby;

    private List<PlayerListing> listings = new List<PlayerListing>();

    public override void OnEnable()
    {
        base.OnEnable();
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("Currently Not Connected");
            return;
        }
        if (PhotonNetwork.CurrentRoom == null)
        {
            Debug.LogWarning("Room is not Created yet");
            return;
        }
        if (PhotonNetwork.CurrentRoom.Players == null)
        {
            Debug.LogWarning("There are no Players");
            return;
        }

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        };
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < listings.Count; i++)
        {
            Destroy(listings[i].gameObject);
        }
        listings.Clear();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = listings.FindIndex(x => x.player == otherPlayer);
        if (index != -1)
        {
            Destroy(listings[index].gameObject);
            listings.RemoveAt(index);
        }
    }

    public void AddPlayerListing(Player player)
    {
        Debug.Log("Updating Player List");
        int index = listings.FindIndex(x => x.player == player);
        if (index != -1)
        {
            listings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(playerListingPrefab, content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                listings.Add(listing);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        GameLobby.SetActive(true);
        OnEnable();
    }

    public void OnClick_StartGame(int levelIndex)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(levelIndex);
        }
    }
}
