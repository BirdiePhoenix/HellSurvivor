using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FlyingEyePool : MonoBehaviour, IObjectPool
{
    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private EnemySpawner enemySpawner;
    private GameObject player;
    
    [Header("Object Pool")]
    [SerializeField] private int maxPoolSize;
    private readonly Queue<GameObject>  flyingEyePool = new Queue<GameObject>();
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public GameObject GetObject()
    {
        GameObject obj;
        if (flyingEyePool.Count > 0)
        {
            obj = flyingEyePool.Dequeue();
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
        if (flyingEyePool.Count >= maxPoolSize)
        {
            Destroy(obj);//This is in case a lot of object has spawned so we remove some of them 
        }
        else
        {
            obj.SetActive(false);
            obj.transform.position = transform.position;
            flyingEyePool.Enqueue(obj);
        }
    }
}
