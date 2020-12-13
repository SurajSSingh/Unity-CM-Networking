using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public Rigidbody2D rb;

    public float moveSpeed = 5f;

    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        //this.transform.Move
    }

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

       //Debug.Log(movement);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
