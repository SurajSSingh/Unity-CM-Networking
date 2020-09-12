using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ShooterGameManager : MonoBehaviourPunCallbacks
{
    public List<Transform> spawnpoints;
    public GameObject ninjaPrefab;
    private int numberOfPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnpoints.Count >= 3 && PhotonNetwork.IsMasterClient)
        {
            numberOfPlayer = 0;
            foreach(Player p in PhotonNetwork.PlayerList)
            {
                GameObject ninja = PhotonNetwork.Instantiate(ninjaPrefab.name, spawnpoints[numberOfPlayer].position, spawnpoints[numberOfPlayer].rotation);
                ninja.GetComponent<PhotonView>().TransferOwnership(p);
                numberOfPlayer += 1;
            }
            photonView.RPC("RPC_syncPlayers", RpcTarget.All, numberOfPlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
    public void RPC_syncPlayers(int players)
    {
        numberOfPlayer = players;
    }
}
