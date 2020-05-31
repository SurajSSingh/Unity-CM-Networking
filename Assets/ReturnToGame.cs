using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0)){
            SceneManager.LoadScene("Room 2 Pong");
        }
    }
}
