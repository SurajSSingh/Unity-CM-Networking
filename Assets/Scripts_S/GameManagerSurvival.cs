using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class GameManagerSurvival : MonoBehaviourPunCallbacks 
{
public GameObject PlayerPrefab; 
    void Start()
    {
        
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

