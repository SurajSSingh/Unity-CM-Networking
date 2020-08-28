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
        if (PhotonNetwork.IsConnected && !photonView.IsMine)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
		{
            if (PhotonNetwork.IsConnected)
            {
				photonView.RPC("Shoot", RpcTarget.All, firePoint.position, firePoint.rotation, this.transform.parent);
			}
            else
            {
				Shoot(firePoint.position, firePoint.rotation, this.transform.parent);
			}
		}
	}

	[PunRPC]
	void Shoot(Vector3 pos, Quaternion rot, Transform parent)
	{
		Instantiate(bulletPrefab, pos, rot, parent);
	}
}