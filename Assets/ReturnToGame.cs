using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{

    public GameObject PauseMenu;

    void Start()
    {
        CloseMenu();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape)){
            PauseMenu.SetActive(true);
        }
        Debug.Log(Input.GetKey(KeyCode.Escape));
    }

    public void CloseMenu()
    {
        PauseMenu.SetActive(false);
    }
}
