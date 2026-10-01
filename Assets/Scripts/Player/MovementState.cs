using System;
using UnityEngine;

public class MovementState : MonoBehaviour
{
    public enum MoveState
    {
        Idle,
        Run,
        Die
    }
    
    public MoveState CurrentMoveState { get; private set; }
    
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    private const string IdleAnim = "Idle";
    private const string RunAnim = "Run";
    private const string DieAnim = "Die";
    public static Action<MoveState> OnMoveStateChange;
    private float xPosLastFrame;
    private float yPosLastFrame;
    
    public void SetMoveState(MoveState moveState)
    {
        if (moveState == CurrentMoveState) return;

        switch (moveState)
        {
            case MoveState.Idle:
                HandleIdle();
                break;
            case MoveState.Run:
                HandleRun();
                break;
            case MoveState.Die:
                HandleDie();
                break;
            default:
                Debug.LogError($"{moveState} is an invalid movement state!");
                break;
        }
        
        OnMoveStateChange?.Invoke(moveState);
        CurrentMoveState = moveState;
    }

    private void HandleIdle()
    {
        animator.Play(IdleAnim);
    }

    private void HandleRun()
    {
        animator.Play(RunAnim);
    }

    private void HandleDie()
    {
        animator.Play(DieAnim);
    }
}
