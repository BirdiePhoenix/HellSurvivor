using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MoveStateManager enemyMoveStateManager;
    [SerializeField] private SpriteRenderer spriteRenderer; 
    [SerializeField] private Rigidbody2D enemyRb;
    
    private Vector2 playerDirection;

    public Vector2 PlayerDirection
    {
        get => playerDirection;
        set => playerDirection = value;
    }
    
    private GameObject player;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

        if (!enemySetup.IsDead)
        {
            EnemyMove();
        }
        else if (enemySetup.IsDead)
        {
            enemyMoveStateManager.SetMoveState(MoveStateManager.MoveState.Die);
        }
    }

    void EnemyMove()
    {
        if (!enemySetup.IsInRange)
        {
            PlayerDirection = (player.transform.position - transform.position).normalized;
            enemyRb.MovePosition(enemyRb.position + PlayerDirection * (enemySetup.CurrentMovementSpeed * Time.fixedDeltaTime));
            enemyMoveStateManager.SetMoveState(MoveStateManager.MoveState.Run);
        }
        else
        {
            enemyMoveStateManager.SetMoveState(MoveStateManager.MoveState.Idle);
            // if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.FlyingEye)
            // {
            //     enemyMoveStateManager.SetMoveState(MoveStateManager.MoveState.Idle);
            // }
            // else if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.Slime)
            // {
            //     enemyMoveStateManager.SetMoveState(MoveStateManager.MoveState.Attack);
            // }
        }
    }
}
