using System.Collections.Generic;
using UnityEngine;

public class SlimePool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject enemyPrefab;
    private Queue<GameObject>  slimePool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        GameObject obj;
        if (slimePool.Count > 0)
        {
            obj = slimePool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(enemyPrefab, transform.position, transform.rotation);
        }

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        slimePool.Enqueue(obj);
    }
}
