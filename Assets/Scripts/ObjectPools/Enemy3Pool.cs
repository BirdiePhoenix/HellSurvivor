using System.Collections.Generic;
using UnityEngine;

public class Enemy3Pool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Queue<GameObject>  enemy3Pool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        GameObject obj;
        if (enemy3Pool.Count > 0)
        {
            obj = enemy3Pool.Dequeue();
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
        enemy3Pool.Enqueue(obj);
    }
}
