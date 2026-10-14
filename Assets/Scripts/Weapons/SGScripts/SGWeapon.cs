using System.Collections;
using UnityEngine;

public class SGWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private DirectionState directionState;
    [SerializeField] private SGBulletPool sgBulletPool;
    [SerializeField] private GameObject[] directions;
    [SerializeField] private CalculateDistance calculateDistance;
    
    private GameObject nearestEnemy;
    private GameObject[] allEnemies;
    private float distance;
    private float nearestDistance = 10000;

    public GameObject[] Directions
    {
        get => directions;
        set => directions = value;
    }
    private WeaponStorage weaponStorage;

    private Vector2 shootingDirection;
    public Vector2 ShootingDirection
    {
        get => shootingDirection;
        set => shootingDirection = value;
    }
    
    private bool hasStartedShooting;
    public bool HasStartedShooting
    {
        get => hasStartedShooting;
        set => hasStartedShooting = value;
    }

    private void Start()
    {
        //enemySpawner = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawner>();
        sgBulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<SGBulletPool>();
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
    }

    public void TriggerShooting()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < weaponStorage.SgBulletMagSize; i++)
        {
            GameObject bullet = sgBulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<SGBulletBehaviour>().ShootDirection = calculateDistance.CalculateClosestEnemy();
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            StartCoroutine(DeactivateBullet(bullet));
        }
        yield return new WaitForSeconds(weaponStorage.SgBulletReloadSpeed);
        
        StartCoroutine(Shoot());
    }
    
    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(weaponStorage.SgBulletRange);
        sgBulletPool.ReturnObject(bullet);
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
