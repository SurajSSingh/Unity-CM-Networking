using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Bulet : MonoBehaviour
{

	public float speed = 1000f;
	public Rigidbody2D rb;
	public BulletType self;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent <Rigidbody2D>();
		rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		PrefabWeapon enemy = hitInfo.GetComponent<PrefabWeapon>();
        if (enemy != null)
        {
            enemy.ChangeHealth(self.Damage);
        }
        if (this.transform.parent != hitInfo.transform)
		{
			Destroy(gameObject);
		}
	}

}