using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator playerAnimator;

    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private MovementState playerMovementState;
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
            playerMovementState.SetMoveState(MovementState.MoveState.Run);
            
            if (moveInput.x > 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
                
            }
            else if (moveInput.x < 0)
            {
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        }
        else
        {
            //playerAnimator.SetBool("isRunning", false);
            playerMovementState.SetMoveState(MovementState.MoveState.Idle);
        } 
    }
}
