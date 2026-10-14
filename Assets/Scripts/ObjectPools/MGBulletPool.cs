using System.Collections.Generic;
using UnityEngine;

public class MGBulletPool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject mgBulletPrefab;
    private Queue<GameObject>  mgBulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (mgBulletPool.Count > 0)
        {
            GameObject obj = mgBulletPool.Dequeue();
            obj.SetActive(true);
            obj.GetComponent<MGBulletBehaviour>().enabled = true;
            return obj;
        }

        return Instantiate(mgBulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.GetComponent<MGBulletBehaviour>().enabled = false;
        mgBulletPool.Enqueue(obj);
    }
}
