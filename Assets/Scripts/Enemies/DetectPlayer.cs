using System;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{//Detects if the player is close enough for the enemy to attack
    [Header("References")]
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MoveStateManager moveStateManager;

    [Header("Local variables")]
    [SerializeField] private float distanceToAttack;
    [SerializeField] private float distanceToStop;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemySetup.IsInRange = true;
            enemyAttack.TriggerAttack();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemySetup.IsInRange = false;
        }
    }
}
