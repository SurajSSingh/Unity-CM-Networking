using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombie : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                      target.position,
                                                      speed * Time.deltaTime);
        Vector2 lookDir = (Vector2)target.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.GetComponent<SurvivalGameManager>() != null)
        {
            Time.timeScale = 0.0f;
            Debug.Log("End game");
        }
        Destroy(this.gameObject);
    }
}
