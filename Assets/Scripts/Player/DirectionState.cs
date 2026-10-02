using System;
using UnityEngine;

public class DirectionState : MonoBehaviour
{
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
                break;
            case LookDirection.Right:
                break;
            default:
                Debug.LogError($"{lookDirection} is an invalid look direction!");
                break;
        }
        
        OnLookDirectionChange?.Invoke(lookDirection);
        CurrentDirection = lookDirection;
    }
}
