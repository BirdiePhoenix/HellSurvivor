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
    public CapsuleCollider2D CapsuleCollider2D{ get { return capsuleCollider2D; } set { capsuleCollider2D = value; } }
    private float currentHealth;
    private FireProjectile fireProjectile;
    private EnemyPool enemyPool;
    private CoinPool coinPool;

    private void Start()
    {
        enemyPool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyPool>();
        coinPool = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<CoinPool>();
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
                if (enemySetup.IsInRange)
                {
                    enemySetup.IsInRange = false;
                }
                StartCoroutine(ReturnEnemy());
                GameObject coin = coinPool.GetObject();
                coin.transform.position = transform.position;
                
            }
        }
    }

    private IEnumerator ReturnEnemy()
    {
        yield return new WaitForSeconds(0.75f);
        enemyPool.ReturnObject(gameObject);
        enemySetup.IsDead = false;
        enemySetup.CurrentHealth = enemySetup.CurrentMaxHealth;
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
