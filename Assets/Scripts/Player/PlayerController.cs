using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    [Header("References")]
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private MoveStateManager playerMoveStateManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private DirectionState directionState;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gameStateManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void Update()
    {
        if (!playerSetup.IsDead)
        {
            MovePlayer();
        }

        if (playerInputActions.Player.Pause.IsPressed())
        {
            gameStateManager.SetGameState(GameStateManager.GameState.Pause);
        }
        
    }

    private void MovePlayer()
    {
        moveInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * playerSetup.CurrentMovementSpeed, moveInput.y * playerSetup.CurrentMovementSpeed);

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            //playerAnimator.SetBool("isRunning", true);
            playerMoveStateManager.SetMoveState(MoveStateManager.MoveState.Run);
            
            if (moveInput.x > 0)
            {
                directionState.SetLookDirection(DirectionState.LookDirection.Right, this.transform);
            }
            else if (moveInput.x < 0)
            {
                directionState.SetLookDirection(DirectionState.LookDirection.Left, this.transform);
            }
            else if (moveInput.y > 0)
            {
                directionState.SetLookDirection(DirectionState.LookDirection.Up,  this.transform);
            }
            else if (moveInput.y < 0)
            {
                directionState.SetLookDirection(DirectionState.LookDirection.Down,  this.transform);
            }
        }
        else
        {
            playerMoveStateManager.SetMoveState(MoveStateManager.MoveState.Idle);
        } 
    }
}
