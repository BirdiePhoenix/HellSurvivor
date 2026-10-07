using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private MovementState moveState;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private BarUI healthBar;
    private float barValue;

    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<BarUI>();
    }

    public void TakeDamage(float damage)
    {
        playerSetup.CurrentHealth -= damage;
        ChangeHealthBar();
        StartCoroutine(ChangeColor());

        
        if (playerSetup.CurrentHealth <= 0 && !playerSetup.IsDead)
        {
            moveState.SetMoveState(MovementState.MoveState.Die);
            playerSetup.IsDead = true;
            Debug.Log("Player is dead");
            
        }
        Debug.Log("Hit");
    }

    private void ChangeHealthBar()
    {
        barValue = Mathf.Clamp(playerSetup.CurrentHealth, 0, playerSetup.CurrentMaxHealth);
        healthBar.SetValue(barValue);
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
