using System;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private SO_Bullet bulletSO;
    private FireProjectile fireProjectile;
    private BulletPool bulletPool;
    private Rigidbody2D bulletRb;
    private Vector2 shootDirection;
  
    private GameObject nearestEnemy;
    private GameObject player;
    private GameObject[] allEnemies;
    private float distance;
    private float nearestDistance = 10000;

    private bool hasCalculated;
    private void Start()
    {
        bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<BulletPool>();
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy && !hasCalculated)
        {
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            CalculateClosestEnemy();
            hasCalculated = true;
        }
        else
        {
            hasCalculated = false;
        }
        
        bulletRb.MovePosition(bulletRb.position + shootDirection * (bulletSO.ShootingSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            bulletPool.ReturnObject(gameObject);
            other.GetComponent<EnemyHealth>().TakeDamage(bulletSO.Damage);
        }
    }
    
    public void CalculateClosestEnemy()
    {
        
        for (int i = 0; i < allEnemies.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, allEnemies[i].transform.position);

            if (distance < nearestDistance && !allEnemies[i].GetComponent<EnemySetup>().IsDead)
            {
                nearestEnemy = allEnemies[i];
                nearestDistance = distance;
            }
        }
        
        shootDirection = (nearestEnemy.transform.position - transform.position).normalized;
    }
}
