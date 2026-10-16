using System.Collections.Generic;
using UnityEngine;

public class SniperBulletPool : MonoBehaviour, IObjectPool
{
    [Header("Prefab")]
    [SerializeField] private GameObject sniperBulletPrefab;
    
    [Header("Object Pool")]
    [SerializeField] private int maxPoolSize;
    private readonly Queue<GameObject>  sniperBulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (sniperBulletPool.Count > 0)
        {
            GameObject obj = sniperBulletPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(sniperBulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = transform.position;
        sniperBulletPool.Enqueue(obj);
    }
}
