using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Queue<GameObject>  bulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (bulletPool.Count > 0)
        {
            GameObject obj = bulletPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(bulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        bulletPool.Enqueue(obj);
    }
}
