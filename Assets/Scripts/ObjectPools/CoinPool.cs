using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour, IObjectPool
{
    [Header("Prefab")]
    [SerializeField] private GameObject coinPrefab;
    
    [Header("Object Pool")]
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
        obj.SetActive(false);
        obj.transform.position = transform.position;
        coinPool.Enqueue(obj);
    }
}
