using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject coinPrefab;
    private Queue<GameObject> coinPool = new  Queue<GameObject>();
    public GameObject GetObject()
    {
        if (coinPool.Count > 0)
        {
            GameObject obj = coinPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(coinPrefab);
    }
    
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        coinPool.Enqueue(obj);
    }
}
