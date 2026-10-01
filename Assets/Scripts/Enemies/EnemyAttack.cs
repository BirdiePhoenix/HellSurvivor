using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    //[SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private EnemyStartingStats startingStats;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private MovementState moveState;
    
    private PlayerHealth playerHealth;

    private void Start()
    {
        startingStats = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyStartingStats>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Debug.Log(playerHealth);
    }
    

    public void TriggerAttack()
    {
        StartCoroutine(Attack());
    }

    private void DamagePlayer()
    {
        //playerHealth.TakeDamage(enemySetup.CurrentStrength);
    }

    private IEnumerator Attack()
    {
        //moveState.SetMoveState(MovementState.MoveState.Attack);
        playerHealth.TakeDamage(startingStats.CurrentStrength);
        yield return new WaitForSeconds(startingStats.CurrentAttackSpeed);
   
        if (enemyMovement.IsInRange)
        {
            StartCoroutine(Attack());
        }
    }
}
