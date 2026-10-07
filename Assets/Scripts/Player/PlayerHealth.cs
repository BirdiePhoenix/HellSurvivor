using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private MovementState moveState;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float barValue;

    private void Start()
    {
    }

    public void TakeDamage(float damage)
    {
        playerSetup.CurrentHealth -= damage;
        StartCoroutine(ChangeColor());

        
        if (playerSetup.CurrentHealth <= 0 && !playerSetup.IsDead)
        {
            moveState.SetMoveState(MovementState.MoveState.Die);
            playerSetup.IsDead = true;
            Debug.Log("Player is dead");
            
        }
        Debug.Log("Hit");
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
