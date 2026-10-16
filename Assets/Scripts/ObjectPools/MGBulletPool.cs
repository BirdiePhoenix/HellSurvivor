using System.Collections.Generic;
using UnityEngine;

public class MGBulletPool : MonoBehaviour, IObjectPool
{
    [Header("Prefab")]
    [SerializeField] private GameObject mgBulletPrefab;
    
    [Header("Object Pool")]
    [SerializeField] private int maxPoolSize;
    private readonly Queue<GameObject>  mgBulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (mgBulletPool.Count > 0)
        {
            GameObject obj = mgBulletPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(mgBulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        if (mgBulletPool.Count >= maxPoolSize)
        {
            Destroy(obj);//This is in case a lot of object has spawned so we remove some of them 
        }
        else
        {
            obj.SetActive(false);
            obj.transform.position = transform.position;
            mgBulletPool.Enqueue(obj);
        }
    }
}
