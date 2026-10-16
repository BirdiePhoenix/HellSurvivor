using System;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MoveStateManager moveStateManager;

    [SerializeField] private float distanceToAttack;
    [SerializeField] private float distanceToStop;
    
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemySetup.IsInRange = true;
            enemyAttack.TriggerAttack();
            // if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.FlyingEye)
            // {
            //     enemyAttack.TriggerAttack();
            // }
            // else if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.Slime)
            // {
            //     moveStateManager.SetMoveState(MoveStateManager.MoveState.Attack);
            // }
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
