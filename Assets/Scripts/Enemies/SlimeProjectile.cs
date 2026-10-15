using System;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    private IObjectPool bulletPool;
    private Rigidbody2D bulletRb;
    private Vector2 shootDirection;
    private GameObject player;
    
    [SerializeField] private float projectileSpeed;
    [SerializeField] private SO_EnemyStats enemyStats;

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
        ShootDirection = (player.transform.position - transform.position).normalized;
    }

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
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
}
