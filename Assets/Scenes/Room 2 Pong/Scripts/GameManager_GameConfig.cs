using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_GameConfig : MonoBehaviour
{

    public GameObject pong;
    public GameObject pongplayer;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // This puppy will run on the first frame and will leave you alone
    void Start()
    {

        //This still creates memes
        bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));


        Instantiate(pong);
        
        GameObject pongplayer1 = Instantiate (pongplayer);
        GameObject pongplayer2 = Instantiate (pongplayer);
        
        pongplayer1.GetComponent<Pong_Paddles>().Init(true);
        pongplayer2.GetComponent<Pong_Paddles>().Init(false);
        
    }

}
