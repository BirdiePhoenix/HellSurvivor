using System.Collections.Generic;
using UnityEngine;

public class SGBulletPool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject sgBulletPrefab;
    private Queue<GameObject>  sgBulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (sgBulletPool.Count > 0)
        {
            GameObject obj = sgBulletPool.Dequeue();
            obj.SetActive(true);
            obj.GetComponent<SGBulletBehaviour>().enabled = true;
            return obj;
        }

        return Instantiate(sgBulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.GetComponent<MGBulletBehaviour>().enabled = false;
        sgBulletPool.Enqueue(obj);
    }
}
