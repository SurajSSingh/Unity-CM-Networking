using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Pong_Ball : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public float speed;
    
    float radius;


    Vector2 direction;

    public Winmanager wm;

    void Start()
    {
        wm = GameObject.Find("Canvas").GetComponent<Winmanager>();
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }    

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < GameManager_GameConfig.bottomLeft.y + radius/6 && direction.y <0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.y > GameManager_GameConfig.topRight.y - radius/6 && direction.y > 0)
        {
            direction.y = -direction.y;

        }





        //If someone wins:
        if (transform.position.x < GameManager_GameConfig.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Player on the right wins!");
            photonView.RPC("WinGame_RPC", RpcTarget.All, false);
        }

        if (transform.position.x > GameManager_GameConfig.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Player on the left wins!");
            photonView.RPC("WinGame_RPC", RpcTarget.All, true);
        }


    }


    //Making the ball bounce when hit with paddle
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bool isRight = other.GetComponent<Pong_Paddles>().isRight;


            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
                 if(speed < 21f)
                 {
                     speed += 1f;
                 }
            }

            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;

                if (speed < 21f)
                {
                    speed += 1f;
                }
            }
        }
    }

    [PunRPC]
    public void WinGame_RPC(bool leftWin)
    {
        wm.WinGame(leftWin);
        Time.timeScale = 0;
    }
}
