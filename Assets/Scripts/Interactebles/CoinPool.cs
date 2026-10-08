using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject coinPrefab;
    private Queue<GameObject> coinPool = new  Queue<GameObject>();
    public GameObject GetObject()
    {
        GameObject obj;
        if (coinPool.Count > 0)
        {
            obj = coinPool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(coinPrefab, transform.position, transform.rotation);
        }

        return obj;
    }
    
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        coinPool.Enqueue(obj);
    }
}
