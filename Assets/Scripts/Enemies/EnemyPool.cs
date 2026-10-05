using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject enemyPrefab;
    private Queue<GameObject>  enemyPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (enemyPool.Count > 0)
        {
            GameObject obj = enemyPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(enemyPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        enemyPool.Enqueue(obj);
    }
}
