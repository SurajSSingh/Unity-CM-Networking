using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PrefabWeapon : MonoBehaviourPunCallbacks
{

	public Transform firePoint;
	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update()
	{
        //if (!photonView.IsMine)
        //{
        //    return;
        //}
        if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, this.transform.parent);
	}
}