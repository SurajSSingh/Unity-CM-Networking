using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager_GameConfig : MonoBehaviourPunCallbacks
{

    public GameObject pong;
    public GameObject pongplayer;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // This puppy will run on the first frame and will leave you alone
    void Start()
    {

        //This still creates memes

       
        bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));

        


        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient) {
            PhotonNetwork.Instantiate(pong.name, pong.transform.position, pong.transform.rotation);

            GameObject pongplayer1 = PhotonNetwork.Instantiate(pongplayer.name, pongplayer.transform.position, pongplayer.transform.rotation);
            GameObject pongplayer2 = PhotonNetwork.Instantiate(pongplayer.name, pongplayer.transform.position, pongplayer.transform.rotation);

            Debug.Log(PhotonNetwork.PlayerListOthers[0]);

            pongplayer1.GetComponent<Pong_Paddles>().Init(true);
            pongplayer2.GetComponent<Pong_Paddles>().Init(false, PhotonNetwork.PlayerListOthers[0]);
        }
        else if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Normal Non-Networked Game");

            Instantiate(pong, pong.transform.position, pong.transform.rotation);

            GameObject pongplayer1 = Instantiate(pongplayer, pongplayer.transform.position, pongplayer.transform.rotation);
            GameObject pongplayer2 = Instantiate(pongplayer, pongplayer.transform.position, pongplayer.transform.rotation);

            pongplayer1.GetComponent<Pong_Paddles>().Init(true);
            pongplayer2.GetComponent<Pong_Paddles>().Init(false);
        }

        
        
    }

}
