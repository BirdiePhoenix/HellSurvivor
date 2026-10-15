using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlyingEyePool : MonoBehaviour, IObjectPool
{
    [SerializeField] private GameObject enemyPrefab;
    private Queue<GameObject>  flyingEyePool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        GameObject obj;
        if (flyingEyePool.Count > 0)
        {
            obj = flyingEyePool.Dequeue();
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
        flyingEyePool.Enqueue(obj);
    }
}
