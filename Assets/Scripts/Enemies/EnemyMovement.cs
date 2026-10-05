using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyStartingStats  startingStats;
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MovementState enemyMovementState;
    [SerializeField] private SpriteRenderer spriteRenderer; 

    public Rigidbody2D enemyRb;
    private GameObject player;
    private float distance;
    [SerializeField] private float stoppingDistance;
    private Vector2 moveDirection;
    
    private float moveSpeed;
    
    private bool isInRange;
    
    void Start()
    {
        startingStats = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyStartingStats>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        //moveSpeed = enemySetup.CurrentMovementSpeed; 
        moveSpeed = startingStats.CurrentMovementSpeed;
        Debug.Log(moveSpeed);
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
            enemyRb.MovePosition(enemyRb.position + lookDirection * moveSpeed * Time.fixedDeltaTime);
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
