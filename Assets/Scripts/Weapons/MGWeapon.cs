using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class MGWeapon : MonoBehaviour, IWeapon
{
    //Redo!!!
    [SerializeField] private DirectionState directionState;
    [SerializeField] private MGBulletPool mgBulletPool;
    private float weaponReloadSpeed;
    
    private GameObject nearestEnemy;
    private GameObject player;
    private GameObject[] allEnemies;
    private float distance;
    private float nearestDistance = 10000;

    public float WeaponReloadSpeed
    {
        get => weaponReloadSpeed;
        set => weaponReloadSpeed = value;
    }

    private bool hasStartedShooting;

    public bool HasStartedShooting
    {
        get => hasStartedShooting;
        set => hasStartedShooting = value;
    }

    private EnemySpawner enemySpawner;
    private DirectionState.LookDirection lookDirection;
    
    private Vector2 shootingDirection;

    public Vector2 ShootingDirection
    {
        get => shootingDirection;
        set => shootingDirection = value;
    }


    private void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawner>();
        mgBulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<MGBulletPool>();
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
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        CalculateClosestEnemy();
        GameObject bullet = mgBulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        StartCoroutine(DeactivateBullet(bullet));
        yield return new WaitForSeconds(weaponReloadSpeed);
        
        StartCoroutine(Shoot());
        
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(weaponReloadSpeed);
        mgBulletPool.ReturnObject(bullet);
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
        
        ShootingDirection = (nearestEnemy.transform.position - transform.position).normalized;
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
