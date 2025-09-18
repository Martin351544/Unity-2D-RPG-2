using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnWait = 5f; 
    public Transform[] spawnPoints;
    public int enemiesSpawned; 
    public int maxEnemies = 3;

    void Start()
    {
        StartCoroutine(SpawnEnemies()); 
    }

    IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < maxEnemies)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                if (enemiesSpawned >= maxEnemies)
                    break;

                Vector3 spawnPos = spawnPoint.position;
                spawnPos.z = 0f; 

                GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                enemiesSpawned++;

                Enemy_Health enemyHealth = enemy.GetComponent<Enemy_Health>();

                if (enemyHealth != null)
                {   
                    enemyHealth.SetSpawner(this);
                }

                SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sortingLayerName = "enemylayer";
                    sr.sortingOrder = 10;
                }

                yield return new WaitForSeconds(spawnWait);
            }
        }

        Debug.Log("Max enemies reached.");
    }
}
