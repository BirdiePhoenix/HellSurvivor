using System;
using System.Collections;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private SO_EnemyStats enemyStats;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileRange;
    
    [Header("References")]
    private IObjectPool bulletPool;
    private Rigidbody2D bulletRb;
    private Vector2 shootDirection;
    private GameObject player;
    
    public Vector2 ShootDirection
    {
        get => shootDirection;
        set => shootDirection = value;
    }

    private void Awake()
    {
        bulletPool = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<SlimeProjectilePool>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateBullet());
    }

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ShootDirection = (player.transform.position - transform.position).normalized;
        bulletRb.MovePosition(bulletRb.position + ShootDirection * (projectileSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bulletPool.ReturnObject(gameObject);
            other.GetComponent<PlayerHealth>().TakeDamage(enemyStats.Strength);
        }
    }
    
    private IEnumerator DeactivateBullet()
    {
        yield return new WaitForSecondsRealtime(projectileRange);
        bulletPool.ReturnObject(gameObject);
    }
}
