using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerSurvival : MonoBehaviourPunCallbacks 
{
    public GameObject PlayerPrefab; 
    public List<Transform> playerspawn;
    public int score = 0;
    public GameObject endScreen;

    void Start()
    {
        score = 0;
        endScreen.SetActive(false);
        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
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

    public void EndGame()
    {
        photonView.RPC("RPC_End",RpcTarget.All);
    }

    [PunRPC]
    public void RPC_End()
    {
        endScreen.SetActive(true);
        endScreen.GetComponentInChildren<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }

    
    public void AddToScore()
    {
        photonView.RPC("RPC_AddScore", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_AddScore()
    {
        score++;
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

