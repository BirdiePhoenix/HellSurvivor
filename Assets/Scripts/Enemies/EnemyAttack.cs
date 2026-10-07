using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private MovementState moveState;
    
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void TriggerAttack()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        //moveState.SetMoveState(MovementState.MoveState.Attack);
        playerHealth.TakeDamage(enemySetup.CurrentStrength);
        yield return new WaitForSeconds(enemySetup.CurrentAttackSpeed);
   
        if (enemyMovement.IsInRange)
        {
            StartCoroutine(Attack());
        }
    }
}
