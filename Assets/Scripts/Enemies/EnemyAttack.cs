using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    //[SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MovementState moveState;
    
    private PlayerHealth playerHealth;

    private void Start()
    {
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
        playerHealth.TakeDamage(enemySetup.CurrentStrength);
        yield return new WaitForSeconds(enemySetup.CurrentAttackSpeed);
   
        if (enemySetup.IsInRange)
        {
            StartCoroutine(Attack());
        }
    }
}
