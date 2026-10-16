using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine.Serialization;

public class EnemyAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MoveStateManager moveStateManager;
    private SlimeProjectilePool slimeProjectilePool;
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        slimeProjectilePool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<SlimeProjectilePool>();
    }

    public void TriggerAttack()
    {
        if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.FlyingEye)
        {
            StartCoroutine(FlyingEyeAttack());
        }
        else if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.Slime)
        {
            StartCoroutine(SlimeAttack());
        }
    }

    private IEnumerator FlyingEyeAttack()
    {
        //moveState.SetMoveState(MovementState.MoveState.Attack);
        playerHealth.TakeDamage(enemySetup.CurrentStrength);
        yield return new WaitForSeconds(enemySetup.CurrentAttackSpeed);
   
        if (enemySetup.IsInRange)
        {
            StartCoroutine(FlyingEyeAttack());
        }
    }

    private IEnumerator SlimeAttack()
    {   
        SpawnSlimeProjectile();
        yield return new WaitForSeconds(enemySetup.CurrentAttackSpeed);

        if (enemySetup.IsInRange)
        {
            StartCoroutine(SlimeAttack());
        }
    }

    private void SpawnSlimeProjectile()
    {
        GameObject projectile = slimeProjectilePool.GetObject();
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
    }
}
