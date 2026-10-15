using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemySetup enemySetup;
    [SerializeField] private MoveStateManager moveStateManager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CapsuleCollider2D capsuleCollider2D;
    public CapsuleCollider2D CapsuleCollider2D{ get { return capsuleCollider2D; } set { capsuleCollider2D = value; } }
    private float currentHealth;
    private MGWeapon mgWeapon;
    private HighScoreManager highScoreManager;
    private FlyingEyePool flyingEyePool;
    private CoinPool coinPool;

    private void Start()
    {
        flyingEyePool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<FlyingEyePool>();
        highScoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponentInChildren<HighScoreManager>();
        coinPool = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<CoinPool>();
        mgWeapon = GameObject.FindGameObjectWithTag("MGWeapon").GetComponent<MGWeapon>();
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
        flyingEyePool.ReturnObject(gameObject);
        enemySetup.IsDead = false;
        enemySetup.CurrentHealth = enemySetup.CurrentMaxHealth;
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
