using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Paddles : MonoBehaviour
{
    //This function will let GamaManager_GameConfig access all yer memes.
    public void Init(bool isRightPlayer)
    {

        Vector2 pos = Vector2.zero;


        if (isRightPlayer)
        //Creates memes on the right of the screen
        {
            pos = new Vector2(GameManager_GameConfig.topRight.x, 0);
        }
        else //Creates memes on the left of the screen 
        {
            pos = new Vector2(GameManager_GameConfig.bottomLeft.x, 0);
        }
        transform.position = pos;
    }
}
