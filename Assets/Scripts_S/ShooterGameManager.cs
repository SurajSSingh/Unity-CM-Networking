using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ShooterGameManager : MonoBehaviourPunCallbacks
{
    public List<Transform> spawnpoints;
    public GameObject ninjaPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnpoints.Count >= 3 && PhotonNetwork.IsMasterClient)
        {
            int count = 0;
            foreach(Player p in PhotonNetwork.PlayerList)
            {
                GameObject ninja = PhotonNetwork.Instantiate(ninjaPrefab.name, spawnpoints[count].position, spawnpoints[count].rotation);
                photonView.TransferOwnership(p);
                count += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
