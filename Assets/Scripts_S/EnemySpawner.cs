using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemySpawner : MonoBehaviourPun
{
    public GameObject enemyPrefab;
    public Transform goal;

    public float minSpeed;
    public float speedMultiplier = 1;
    public float spawnTimer = 5;

    float increaseTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private void Update()
    {
        if (PhotonNetwork.IsConnected && !PhotonNetwork.IsMasterClient)
        {
            return;
        }
        increaseTimer += Time.deltaTime;
        if (increaseTimer >= 5)
        {
            int choice = Random.Range(0, 3);
            switch (choice)
            {
                case 0:
                    minSpeed += 1f;
                    break;
                case 1:
                    speedMultiplier += 0.1f;
                    break;
                case 2:
                    spawnTimer -= 0.01f;
                    break;
                default:
                    break;
            }
            increaseTimer = 0;
        }
    }

    IEnumerator SpawnEnemy()
    {
        
        while (true)
        {
            photonView.RPC("RPC_Spawn", RpcTarget.All, enemyPrefab.name, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    [PunRPC]
    public void RPC_Spawn(string prefab, Vector3 pos, Quaternion rot)
    {
        GameObject enemy = Instantiate(enemyPrefab, pos, rot);
        enemy.GetComponent<EnemyZombie>().target = goal;
        enemy.GetComponent<EnemyZombie>().speed = Random.Range(minSpeed, minSpeed * speedMultiplier);
    }
}
