using System;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private BulletSetup bulletSetup;
    private IWeapon weapon;
    private IObjectPool bulletPool;
    private Rigidbody2D bulletRb;
    private Vector2 shootDirection;

    public Vector2 ShootDirection
    {
        get => shootDirection;
        set => shootDirection = value;
    }

    // private GameObject nearestEnemy;
    // private GameObject player;
    // private GameObject[] allEnemies;
    // private float distance;
    // private float nearestDistance = 10000;
    //
    // private bool hasCalculated;

    private bool isReady = false;
    private void Start()
    {
        bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<MGBulletPool>();
        weapon = GameObject.FindGameObjectWithTag("MGWeapon").GetComponent<MGWeapon>();
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (isReady)
        {
            shootDirection = weapon.ShootingDirection;
        }
    }

    private void OnDisable()
    {
        isReady = true;
    }

    private void FixedUpdate()
    {
        // if (gameObject.activeInHierarchy && !hasCalculated)
        // {
        //     //allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        //     //CalculateClosestEnemy();
        //     hasCalculated = true;
        // }

        bulletRb.MovePosition(bulletRb.position + shootDirection * (bulletSetup.BulletSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            bulletPool.ReturnObject(gameObject);
            other.GetComponent<EnemyHealth>().TakeDamage(bulletSetup.BulletDamage);
        }
    }
    
    // public void CalculateClosestEnemy()
    // {
    //     
    //     for (int i = 0; i < allEnemies.Length; i++)
    //     {
    //         distance = Vector3.Distance(this.transform.position, allEnemies[i].transform.position);
    //
    //         if (distance < nearestDistance && !allEnemies[i].GetComponent<EnemySetup>().IsDead)
    //         {
    //             nearestEnemy = allEnemies[i];
    //             nearestDistance = distance;
    //         }
    //     }
    //     
    //     shootDirection = (nearestEnemy.transform.position - transform.position).normalized;
    // }
}
