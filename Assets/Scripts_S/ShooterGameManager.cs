using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShooterGameManager : MonoBehaviourPunCallbacks
{
    public List<Transform> spawnpoints;
    public GameObject ninjaPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnpoints.Count >= 3)
        {
            GameObject ninja = PhotonNetwork.Instantiate(ninjaPrefab.name, spawnpoints[0].position, spawnpoints[0].rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
