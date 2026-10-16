using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MoveStateManager moveStateManager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private float currentHealth;
    private HighScoreManager highScoreManager;
    private IObjectPool enemyPool;
    private CoinPool coinPool;

    private void OnEnable()
    {
        enemySetup.IsDead = false;
    }

    private void Start()
    {
        GetEnemyPool();
        highScoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponentInChildren<HighScoreManager>();
        coinPool = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<CoinPool>();
        currentHealth = enemySetup.CurrentHealth;
    }

    private void GetEnemyPool()
    {
        if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.FlyingEye)
        {
            enemyPool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<FlyingEyePool>();
        }
        else if (enemySetup.CurrentEnemyType == EnemySetup.EnemyType.Slime)
        {
            enemyPool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<SlimePool>();
        }
    }
    
    public void TakeDamage(int damage)
    {
        if (!enemySetup.IsDead)
        {
            enemySetup.CurrentHealth -= damage;
            StartCoroutine(ChangeColor());
            if (enemySetup.CurrentHealth <= 0)
            {
                moveStateManager.SetMoveState(MoveStateManager.MoveState.Die);
                enemySetup.IsDead = true;
                if (enemySetup.IsInRange)
                {
                    enemySetup.IsInRange = false;
                }
                StartCoroutine(ReturnEnemy());
                GameObject coin = coinPool.GetObject();
                coin.transform.position = transform.position;
                highScoreManager.UpdateScore(100);
            }
        }
    }

    private IEnumerator ReturnEnemy()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        enemyPool.ReturnObject(gameObject);
        enemySetup.CurrentHealth = enemySetup.CurrentMaxHealth;
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
