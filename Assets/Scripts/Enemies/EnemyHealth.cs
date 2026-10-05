using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MovementState moveState;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CapsuleCollider2D capsuleCollider2D;
    private int currentHealth;

    private void Start()
    {
        currentHealth = enemySetup.CurrentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!enemySetup.IsDead)
        {
            enemySetup.CurrentHealth -= damage;
            StartCoroutine(ChangeColor());
            if (enemySetup.CurrentHealth <= 0)
            {
                moveState.SetMoveState(MovementState.MoveState.Die);
                enemySetup.IsDead = true;
                capsuleCollider2D.enabled = false;
                Debug.Log("Enemy is dead");
            }
            Debug.Log("Hit");
        }
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
