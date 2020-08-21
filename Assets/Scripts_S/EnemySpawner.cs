using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
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
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
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
            GameObject enemy = Instantiate(enemyPrefab,this.transform);
            enemy.GetComponent<EnemyZombie>().target = goal;
            enemy.GetComponent<EnemyZombie>().speed = Random.Range(minSpeed, minSpeed * speedMultiplier);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
