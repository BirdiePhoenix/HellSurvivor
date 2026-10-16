using System.Collections.Generic;
using UnityEngine;

public class SlimePool : MonoBehaviour, IObjectPool
{
    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private EnemySpawner enemySpawner;
    
    [Header("Object Pool")]
    [SerializeField] private int maxPoolSize;
    private readonly Queue<GameObject>  slimePool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        GameObject obj;
        if (slimePool.Count > 0)
        {
            obj = slimePool.Dequeue();
            obj.transform.position = enemySpawner.GenerateSpawnPoint().transform.position;
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(enemyPrefab, enemySpawner.GenerateSpawnPoint().transform.position, transform.rotation);
        }

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = transform.position;
        slimePool.Enqueue(obj);
    }
}
