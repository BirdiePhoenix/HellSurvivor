using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject bulletPrefab;
    private Queue<GameObject>  bulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (bulletPool.Count > 0)
        {
            GameObject obj = bulletPool.Dequeue();
            obj.SetActive(true);
            obj.GetComponent<BulletBehaviour>().enabled = true;
            return obj;
        }

        return Instantiate(bulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.GetComponent<BulletBehaviour>().enabled = false;
        bulletPool.Enqueue(obj);
    }
}
