using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooting : MonoBehaviourPunCallbacks
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

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
                photonView.RPC("RPC_Shoot", RpcTarget.All, firepoint.position, firepoint.rotation);
            }
            else
            {
                RPC_Shoot(firepoint.position, firepoint.rotation);
            }
            
        }
    }

    [PunRPC]
    void RPC_Shoot(Vector3 pos, Quaternion rot)
    {
        GameObject bullet = Instantiate(bulletPrefab, pos, rot);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
