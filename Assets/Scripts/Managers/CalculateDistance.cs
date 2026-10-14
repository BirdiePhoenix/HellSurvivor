using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CalculateDistance : MonoBehaviour
{
    private GameObject nearestEnemy;
    private GameObject player;
    private GameObject[] allEnemies;
    private float distance;
    private float nearestDistance = 10000;
   
    public GameObject NearestEnemy
    {
        get { return nearestEnemy; }
        set { nearestEnemy = value; }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public Vector2 CalculateClosestEnemy()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < allEnemies.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, allEnemies[i].transform.position);

            if (distance < nearestDistance)
            {
                NearestEnemy = allEnemies[i];
                nearestDistance = distance;
            }
        }
        
        return (nearestEnemy.transform.position - transform.position).normalized;
    }
}
