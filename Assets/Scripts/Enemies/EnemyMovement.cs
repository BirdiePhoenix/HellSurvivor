using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MovementState enemyMovementState;
    [SerializeField] private SpriteRenderer spriteRenderer; 
    [SerializeField] private Rigidbody2D enemyRb;
    
    private GameObject player;
    private float distance;
    private Vector2 moveDirection;
    private bool isInRange;

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
            EnemyMove(isInRange);
        }
        else if (enemySetup.IsDead)
        {
            enemyMovementState.SetMoveState(MovementState.MoveState.Die);
        }
    }

    void EnemyMove(bool _isInRange)
    {
        if (!_isInRange)
        {
            distance = Vector2.Distance(player.transform.position, transform.position);
            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.MovePosition(enemyRb.position + lookDirection * (enemySetup.CurrentMovementSpeed * Time.fixedDeltaTime));
            enemyMovementState.SetMoveState(MovementState.MoveState.Run);
        }
        else
        {
            enemyMovementState.SetMoveState(MovementState.MoveState.Idle);
        }
    }

    public bool IsInRange
    {
        get { return isInRange; }
        set { isInRange = value; }
    }
}
