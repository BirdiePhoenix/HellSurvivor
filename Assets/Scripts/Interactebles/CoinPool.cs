using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour, IObjectPool
{
    [Header("Prefab")]
    [SerializeField] private GameObject coinPrefab;
    [Header("Variables")]
    [SerializeField] private int maxPoolSize;
    private readonly Queue<GameObject> coinPool = new  Queue<GameObject>();
    public GameObject GetObject()
    {
        GameObject obj;
        if (coinPool.Count > 0) //In case the queue contains objects we remove one and makes it active
        {
            obj = coinPool.Dequeue();
            obj.SetActive(true);
        }
        else //else we create a new one
        {
            obj = Instantiate(coinPrefab, transform.position, transform.rotation);
        }

        return obj;
    }
    
    public void ReturnObject(GameObject obj)
    {
        if (coinPool.Count >= maxPoolSize)
        {
            Destroy(obj);//This is in case a lot of object has spawned so we remove some of them 
        }
        else
        {
            obj.SetActive(false);
            coinPool.Enqueue(obj);
        }
    }
}
