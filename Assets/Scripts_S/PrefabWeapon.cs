using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PrefabWeapon : MonoBehaviourPunCallbacks
{

	public Transform firePoint;
	public GameObject bulletPrefab;

	float health  = 100;

	// Update is called once per frame
	void Update()
	{
        if (PhotonNetwork.IsConnected && !photonView.IsMine)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
		{
            if (PhotonNetwork.IsConnected)
            {
				photonView.RPC("Shoot", RpcTarget.All, firePoint.position, firePoint.rotation);
			}
            else
            {
				Shoot(firePoint.position, firePoint.rotation);
			}
		}
	}

	[PunRPC]
	void Shoot(Vector3 pos, Quaternion rot)
	{
		Instantiate(bulletPrefab, pos, rot);
	}

	public void ChangeHealth(float damage)
    {
		if (PhotonNetwork.IsConnected)
		{
			photonView.RPC("RPC_ChangeHealth", RpcTarget.All, damage);
		}
		else
		{
			health -= damage;
		}
	}

	[PunRPC]
	public void RPC_ChangeHealth(float damage)
	{
		this.health -= damage;
        if (health <= 0)
        {
			if (PhotonNetwork.IsConnected)
			{
				PhotonNetwork.Destroy(this.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
        }
	}
}