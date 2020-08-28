using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class GameManagerSurvival : MonoBehaviourPunCallbacks 
{
public GameObject PlayerPrefab; 
public List<Transform> playerspawn;

    void Start()
    {
        if(PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.Instantiate(PlayerPrefab.name,new Vector3(0,0), Quaternion.identity, 0);
            int count = 0;
            foreach(Player p in PhotonNetwork.PlayerList)
            {
                GameObject survivor = PhotonNetwork.Instantiate(PlayerPrefab.name, playerspawn[count].position, playerspawn[count].rotation);
                survivor.GetComponent<PhotonView>().TransferOwnership(p);
                count += 1;
            }

        }
    }

    
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();   
        }
}

