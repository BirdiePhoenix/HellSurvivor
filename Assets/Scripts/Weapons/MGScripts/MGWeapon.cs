using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class MGWeapon : MonoBehaviour, IWeapon
{
    //Redo!!!
    [SerializeField] private DirectionState directionState;
    [SerializeField] private MGBulletPool mgBulletPool;
    [SerializeField] private float bulletSpread;
    [SerializeField] private CalculateDistance calculateDistance;
    
    private WeaponStorage weaponStorage;
    
    private GameObject nearestEnemy;
    private GameObject player;
    private GameObject[] allEnemies;
    private float distance;
    private float nearestDistance = 10000;

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
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
    }

    private void OnTriggerEnter2D(Collider2D targetEnemy)
    {
        if (targetEnemy.CompareTag("Enemy") && !HasStartedShooting)
        {
            HasStartedShooting = true;
            TriggerShooting();
            //ShootDirection = (targetEnemy.transform.position - transform.position).normalized;
        }
    }
    
    public void TriggerShooting()
    {
        StartCoroutine(Shoot());
    }
    
    private IEnumerator Shoot()
    {
        //allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        //CalculateClosestEnemy();
        ShootingDirection = calculateDistance.CalculateClosestEnemy();

        for (int i = 0; i < weaponStorage.MgBulletMagSize; i++)
        {
            GameObject bullet = mgBulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            StartCoroutine(DeactivateBullet(bullet));

            yield return new WaitForSeconds(bulletSpread);
        }
        yield return new WaitForSeconds(weaponStorage.MgBulletReloadSpeed);
        
        StartCoroutine(Shoot());
        
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(weaponStorage.MgBulletRange);
        mgBulletPool.ReturnObject(bullet);
    }
    
    // public void CalculateClosestEnemy()
    // {
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
    //     ShootingDirection = (nearestEnemy.transform.position - transform.position).normalized;
    // }
}
