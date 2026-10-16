using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectilePool : MonoBehaviour, IObjectPool
{
    [Header("Prefab")]
    [SerializeField] private GameObject slimeProjectilePrefab;
    
    [Header("Object Pool")]
    [SerializeField] private int maxPoolSize;
    private readonly Queue<GameObject>  slimeProjectilePool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (slimeProjectilePool.Count > 0)
        {
            GameObject obj = slimeProjectilePool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(slimeProjectilePrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = transform.position;
        slimeProjectilePool.Enqueue(obj);
    }
}
