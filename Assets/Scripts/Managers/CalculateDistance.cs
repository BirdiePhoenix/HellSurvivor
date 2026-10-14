using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CalculateDistance : MonoBehaviour
{
    private GameObject nearestEnemy;
    private GameObject furthestEnemy;
    private GameObject player;
    private GameObject[] allEnemies;
    private float distance;
    private float nearestDistance;
    private float furthestDistance;
   
    public GameObject NearestEnemy
    {
        get => nearestEnemy;
        set => nearestEnemy = value;
    }

    public GameObject FurthestEnemy
    {
        get => furthestEnemy;
        set => furthestEnemy = value;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public Vector2 CalculateClosestEnemy(bool isSniper)
    {
        nearestDistance = 10000;
        furthestDistance = 0;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < allEnemies.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, allEnemies[i].transform.position);

            if (distance < nearestDistance)
            {
                NearestEnemy = allEnemies[i];
                nearestDistance = distance;
            }

            if (distance > furthestDistance)
            {
                FurthestEnemy = allEnemies[i];
                furthestDistance = distance;
            }
        }

        if (!isSniper)
        {
            
            return (nearestEnemy.transform.position - transform.position).normalized;
        }
        else
        {
            return (furthestEnemy.transform.position - transform.position).normalized;
        }
    }
}
