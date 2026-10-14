using System;
using UnityEngine;

public class DirectionState : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Transform transformRotation;

    public Transform TransformRotation
    {
        get { return transformRotation; }
        set { transformRotation = value; }
    }
    
    private GameObject player;

    private Rigidbody2D rb;


    public enum LookDirection
    {
        Right,
        Left,
        Up,
        Down
    }
    public LookDirection CurrentDirection { get; private set; }
    public static Action<LookDirection> OnLookDirectionChange;
    
    public void SetLookDirection(LookDirection lookDirection, Transform playerTransform)
    {
        if (lookDirection == CurrentDirection) return;

        switch (lookDirection)
        {
            case LookDirection.Right:
                spriteRenderer.flipX = false;
                TransformRotation = playerTransform;
                break;
            case LookDirection.Left:
                spriteRenderer.flipX = true;
                TransformRotation = playerTransform;
                break;
            case LookDirection.Up:
                break;
            case LookDirection.Down:
                break;
            default:
                Debug.LogError($"{lookDirection} is an invalid look direction!");
                break;
        }
        
        OnLookDirectionChange?.Invoke(lookDirection);
        CurrentDirection = lookDirection;
    }
}
