using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class GameManagerSurvival : MonoBehaviourPunCallbacks 
{
public GameObject PlayerPrefab; 
public List<Transform> EnemySpawnPoint;
public Transform playerspawn;
    void Start()
    {
        if(PhotonNetwork.IsConnected){
            PhotonNetwork.Instantiate(PlayerPrefab.name,new Vector3(0,0), Quaternion.identity, 0);
             PhotonNetwork.Instantiate(PlayerPrefab.name,new Vector3(0,0), Quaternion.identity, 0);
              PhotonNetwork.Instantiate(PlayerPrefab.name,new Vector3(0,0), Quaternion.identity, 0);
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

