using System;
using UnityEngine;

public class DirectionState : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private GameObject player;
    [SerializeField] private SGWeapon sgWeapon;
    [SerializeField] private GameObject child;

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
                //child.transform.rotation = Quaternion.Euler(0, 0, 0);
                //FlipShooting();
                break;
            case LookDirection.Left:
                spriteRenderer.flipX = true;
                //child.transform.rotation = Quaternion.Euler(0, -180, 0);
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
