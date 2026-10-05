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
    private EnemyPool enemyPool;

    private void Start()
    {
        enemyPool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyPool>();
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
                StartCoroutine(ReturnEnemy());
            }
        }
    }

    private IEnumerator ReturnEnemy()
    {
        moveState.SetMoveState(MovementState.MoveState.Die);
        enemySetup.IsDead = true;
        capsuleCollider2D.enabled = false;
        yield return new WaitForSeconds(2);
        enemyPool.ReturnObject(gameObject);
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
