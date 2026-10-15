using System.Collections.Generic;
using UnityEngine;

public class Enemy2Pool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Queue<GameObject>  enemy2Pool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        GameObject obj;
        if (enemy2Pool.Count > 0)
        {
            obj = enemy2Pool.Dequeue();
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
        enemy2Pool.Enqueue(obj);
    }
}
