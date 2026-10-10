using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator playerAnimator;

    [SerializeField] private PlayerSetup playerSetup;
    [FormerlySerializedAs("playerMovementState")] [SerializeField] private MoveStateManager playerMoveStateManager;
    [SerializeField] private DirectionState directionState;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
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
                directionState.SetLookDirection(DirectionState.LookDirection.Right);
            }
            else if (moveInput.x < 0)
            {
                directionState.SetLookDirection(DirectionState.LookDirection.Left);
            }
            else if (moveInput.y > 0)
            {
                directionState.SetLookDirection(DirectionState.LookDirection.Up);
            }
            else if (moveInput.y < 0)
            {
                directionState.SetLookDirection(DirectionState.LookDirection.Down);
            }
        }
        else
        {
            //playerAnimator.SetBool("isRunning", false);
            playerMoveStateManager.SetMoveState(MoveStateManager.MoveState.Idle);
        } 
    }
}
