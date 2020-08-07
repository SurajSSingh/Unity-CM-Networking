using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    public Transform content;
    public RoomListing roomListingPrefab;

    private List<RoomListing> listings = new List<RoomListing>();
    public List<GameObject> gameLobbies = new List<GameObject>();

    public override void OnJoinedRoom()
    {
        Debug.Log("Deleting Room List");
        content.DestroyChildren();
        listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Updating Room List");
        foreach(RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.roomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else
            {
                int index = listings.FindIndex(x => x.roomInfo.Name == info.Name);
                if(index == -1)
                {
                    RoomListing listing = Instantiate(roomListingPrefab, content);
                    listing.GameLobby = gameLobbies[info.MaxPlayers-2];
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        listings.Add(listing);
                    }
                }
            }
        }
    }
}
