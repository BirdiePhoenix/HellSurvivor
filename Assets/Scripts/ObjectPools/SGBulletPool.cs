using System.Collections.Generic;
using UnityEngine;

public class SGBulletPool : MonoBehaviour, IObjectPool
{
    [Header("Prefab")]
    [SerializeField] private GameObject sgBulletPrefab;
    
    [Header("Object Pool")]
    [SerializeField] private int maxPoolSize;
    private readonly Queue<GameObject>  sgBulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (sgBulletPool.Count > 0)
        {
            GameObject obj = sgBulletPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(sgBulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        if (sgBulletPool.Count >= maxPoolSize)
        {
            Destroy(obj);//This is in case a lot of object has spawned so we remove some of them 
        }
        else
        {
            obj.SetActive(false);
            obj.transform.position = transform.position;
            sgBulletPool.Enqueue(obj);
        }
    }
}
