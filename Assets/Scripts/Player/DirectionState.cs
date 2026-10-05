using System;
using UnityEngine;

public class DirectionState : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public enum LookDirection
    {
        Left,
        Right
    }

    public LookDirection CurrentDirection { get; private set; }
    
    public static Action<LookDirection> OnLookDirectionChange;
    
    public void SetLookDirection(LookDirection lookDirection)
    {
        if (lookDirection == CurrentDirection) return;

        switch (lookDirection)
        {
            case LookDirection.Left:
                spriteRenderer.flipX = true;
                break;
            case LookDirection.Right:
                spriteRenderer.flipX = false;
                break;
            default:
                Debug.LogError($"{lookDirection} is an invalid look direction!");
                break;
        }
        
        OnLookDirectionChange?.Invoke(lookDirection);
        CurrentDirection = lookDirection;
    }
}
