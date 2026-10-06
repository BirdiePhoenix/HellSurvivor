using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyTypes = new List<GameObject>();
    [SerializeField] private float spawnInterval = 3.5f;

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
        StartCoroutine(SpawnEnemy(spawnInterval, enemyTypes[0]));
    }
    
    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        HasSpawned = true;
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(player.transform.position.x + 5 -5f, player.transform.position.x + 5 + 5), 
            Random.Range(player.transform.position.y + 5 -6f, player.transform.position.y + 5 + 6), 0), Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
}
