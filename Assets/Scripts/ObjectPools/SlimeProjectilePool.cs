using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectilePool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject slimeProjectilePrefab;
    private readonly Queue<GameObject>  slimeProjectilePool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (slimeProjectilePool.Count > 0)
        {
            GameObject obj = slimeProjectilePool.Dequeue();
            obj.SetActive(true);
            //obj.GetComponent<MGBulletBehaviour>().enabled = true;
            return obj;
        }

        return Instantiate(slimeProjectilePrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        //obj.GetComponent<MGBulletBehaviour>().enabled = false;
        slimeProjectilePool.Enqueue(obj);
    }
}
