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
    
    //private Vector2 lowestDistance;
    //private Vector2 distanceToEnemy;

    public GameObject NearestEnemy
    {
        get { return nearestEnemy; }
        set { nearestEnemy = value; }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void CalculateClosestEnemy()
    {
        for (int i = 0; i < allEnemies.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, allEnemies[i].transform.position);

            if (distance < nearestDistance)
            {
                NearestEnemy = allEnemies[i];
                nearestDistance = distance;
            }
        }
    }
    
    // float distanceToClosestEnemy = Vector2.Distance(player.transform.position, ClosestEnemy.transform.position);
    //
    // foreach (GameObject enemy in allEnemies)
    // {
    //     float distanceToCurrent = Vector2.Distance(player.transform.position, enemy.transform.position);
    //
    //     if (distanceToCurrent < distanceToClosestEnemy)
    //     {
    //         ClosestEnemy = enemy;
    //         distanceToClosestEnemy = distanceToCurrent;
    //     }
    // }
}
