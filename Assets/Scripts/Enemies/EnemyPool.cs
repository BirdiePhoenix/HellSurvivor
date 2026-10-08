using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject enemyPrefab;
    private Queue<GameObject>  enemyPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        GameObject obj;
        if (enemyPool.Count > 0)
        {
            obj = enemyPool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(enemyPrefab, transform.position, transform.rotation);
        }

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        enemyPool.Enqueue(obj);
    }
}
