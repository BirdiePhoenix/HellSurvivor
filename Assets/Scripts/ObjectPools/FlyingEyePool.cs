using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FlyingEyePool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private _EnemySpawner enemySpawner;
    private Queue<GameObject>  flyingEyePool = new Queue<GameObject>();
    
    private GameObject player;

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
        obj.SetActive(false);
        obj.transform.position = transform.position;
        flyingEyePool.Enqueue(obj);
    }
}
