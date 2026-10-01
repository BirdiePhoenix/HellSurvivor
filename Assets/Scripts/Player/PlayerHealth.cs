using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private MovementState moveState;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void TakeDamage(int damage)
    {
        playerSetup.CurrentHealth -= damage;
        if (playerSetup.CurrentHealth > 0)
        {
            //moveState.SetMoveState(MovementState.MoveState.Damage);
            StartCoroutine(ChangeColor());
        }
        else if (playerSetup.CurrentHealth <= 0)
        {
            moveState.SetMoveState(MovementState.MoveState.Die);
            playerSetup.IsDead = true;
            OnDeath();
            Debug.Log("Player is dead");
        }
        Debug.Log("Hit");
    }

    private void OnDeath()
    {
        spriteRenderer.flipY = true;
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
