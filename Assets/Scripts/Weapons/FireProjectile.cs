using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class FireProjectile : MonoBehaviour
{
    //Redo!!!
    [SerializeField] private DirectionState directionState;
    [SerializeField] private SO_Bullet mgBullet;
    [SerializeField] private BulletPool bulletPool;

    private bool hasStartedShooting;

    public bool HasStartedShooting
    {
        get => hasStartedShooting;
        set => hasStartedShooting = value;
    }

    private EnemySpawner enemySpawner;
    private DirectionState.LookDirection lookDirection;
    
    private Vector2 shootDirection;

    public Vector2 ShootDirection
    {
        get => shootDirection;
        set => shootDirection = value;
    }


    private void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawner>();
        bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<BulletPool>();
    }

    private void OnTriggerEnter2D(Collider2D targetEnemy)
    {
        if (targetEnemy.CompareTag("Enemy") && !HasStartedShooting)
        {
            HasStartedShooting = true;
            StartCoroutine(Shoot());
            //ShootDirection = (targetEnemy.transform.position - transform.position).normalized;
        }
    }
    
    private IEnumerator Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        StartCoroutine(DeactivateBullet(bullet));
        yield return new WaitForSeconds(mgBullet.ReloadSpeed);
        
        StartCoroutine(Shoot());
        
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(mgBullet.ShootingRange);
        bulletPool.ReturnObject(bullet);
    }
    
    
    
    // if (rb != null)
    // {
    //     
    //     
    //     // switch (directionState.CurrentDirection)
    //     // {
    //     //     case DirectionState.LookDirection.Right:
    //     //         rb.linearVelocity = bullet.transform.right * mgBullet.ShootingSpeed;
    //     //         break;
    //     //     case DirectionState.LookDirection.Left:
    //     //         rb.linearVelocity = bullet.transform.right * -mgBullet.ShootingSpeed;
    //     //         break;
    //     //     case DirectionState.LookDirection.Up:
    //     //         rb.linearVelocity = bullet.transform.up * mgBullet.ShootingSpeed;
    //     //         break;
    //     //     case DirectionState.LookDirection.Down:
    //     //         rb.linearVelocity = bullet.transform.up * -mgBullet.ShootingSpeed;
    //     //         break;
    //     //     default:
    //     //         break;
    //     // }
    // }
}
