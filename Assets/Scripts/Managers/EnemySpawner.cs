using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyTypes = new List<GameObject>();
    [SerializeField] private float spawnInterval = 3.5f;
    [SerializeField] private EnemyPool enemyPool;

    private bool hasSpawned = false;

    public bool HasSpawned 
    { 
        get { return hasSpawned; }
        set { hasSpawned = value; }
    }
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyPool>();
        StartCoroutine(SpawnEnemy(spawnInterval));
    }
    
    private IEnumerator SpawnEnemy(float interval)
    {
        yield return new WaitForSeconds(interval);
        HasSpawned = true;
        GameObject newEnemy = enemyPool.GetObject();
        Vector2 spawnPos = new Vector2(Random.Range(player.transform.position.x + 5 -5f, player.transform.position.x + 5 + 5), 
            Random.Range(player.transform.position.y + 5 -6f, player.transform.position.y + 5 + 6));
        newEnemy.transform.position = spawnPos;
        // Vector3 spawnPos = new Vector3(Random.Range(player.transform.position.x + 5 -5f, player.transform.position.x + 5 + 5), 
        //     Random.Range(player.transform.position.y + 5 -6f, player.transform.position.y + 5 + 6), 0), Quaternion.identity;
        StartCoroutine(SpawnEnemy(interval));
    }
}
