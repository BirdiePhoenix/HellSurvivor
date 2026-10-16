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
        obj.SetActive(false);
        obj.transform.position = transform.position;
        mgBulletPool.Enqueue(obj);
    }
}
