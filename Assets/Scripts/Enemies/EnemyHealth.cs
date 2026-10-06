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
    private FireProjectile fireProjectile;
    private EnemyPool enemyPool;

    private void Start()
    {
        enemyPool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyPool>();
        fireProjectile = GameObject.FindGameObjectWithTag("MGWeapon").GetComponent<FireProjectile>();
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
                StartCoroutine(ReturnEnemy());
            }
        }
    }

    private IEnumerator ReturnEnemy()
    {
        yield return new WaitForSeconds(0.75f);
        enemyPool.ReturnObject(gameObject);
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
