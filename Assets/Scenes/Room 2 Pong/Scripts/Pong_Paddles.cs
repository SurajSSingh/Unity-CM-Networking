using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Pong_Paddles : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public float speed;

    string input;
    public bool isRight;
    float height;

    void Start()
    {
        height = transform.localScale.y;
    }

    //This function will let GamaManager_GameConfig access all yer memes.
    public void Init(bool isRightPlayer)
    {
        isRight = isRightPlayer;
        Vector2 pos = Vector2.zero;


        if (isRightPlayer)
        //Creates memes on the right of the screen
        {
            pos = new Vector2(GameManager_GameConfig.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            input = "Right Player";
        }
        else //Creates memes on the left of the screen 
        {
            pos = new Vector2(GameManager_GameConfig.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "Left Player";
            if (PhotonNetwork.IsConnected)
            {
                foreach(Player p in PhotonNetwork.PlayerListOthers)
                {
                    Debug.Log(p);
                }
                
                Debug.Log(PhotonNetwork.PlayerListOthers);
                photonView.TransferOwnership(PhotonNetwork.PlayerListOthers[0]);
            }
        }
        transform.position = pos;
        transform.name = input;

    }

    void Update()
    {
        
        //Move the players:
        if (PhotonNetwork.IsConnected && !photonView.IsMine)
        {
            return;
        }

        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameManager_GameConfig.bottomLeft.y + height / 2 && move <0)
        {
            move = 0;
        }

        if (transform.position.y > GameManager_GameConfig.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }


        transform.Translate(move * Vector2.up);


    }





}
