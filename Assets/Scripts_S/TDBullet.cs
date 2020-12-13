using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDBullet : MonoBehaviour
{
    public float destoryTimer = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActiveBulletTime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }

    IEnumerator ActiveBulletTime()
    {
        yield return new WaitForSeconds(destoryTimer);
        Destroy(this.gameObject);
    }
}
