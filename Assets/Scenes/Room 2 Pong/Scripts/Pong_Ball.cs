using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Ball : MonoBehaviour
{
    [SerializeField]
    public float speed;

    float radius;


    Vector2 direction;

    void Start()
    {
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
            Time.timeScale = 0;
        }

        if (transform.position.x > GameManager_GameConfig.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Player on the left wins!");
            Time.timeScale = 0;
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
                speed += 1f;
            }

            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
                speed += 1f;
            }
        }
    }


}
