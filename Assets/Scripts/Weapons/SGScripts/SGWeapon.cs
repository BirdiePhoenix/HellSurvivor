using System.Collections;
using UnityEngine;

public class SGWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private DirectionState directionState;
    [SerializeField] private SGBulletPool sgBulletPool;
    [SerializeField] private GameObject[] directions;
    [SerializeField] private CalculateDistance calculateDistance;

    public GameObject[] Directions
    {
        get => directions;
        set => directions = value;
    }
    private WeaponStorage weaponStorage;

    private Vector2 weaponShootingDirection;
    public Vector2 WeaponShootingDirection
    {
        get => weaponShootingDirection;
        set => weaponShootingDirection = value;
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
        //WeaponShootingDirection = calculateDistance.CalculateClosestEnemy();
        for (int i = 0; i < weaponStorage.SgBulletMagSize; i++)
        {
            GameObject bullet = sgBulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<SGBulletBehaviour>().ShootDirection = (directions[i].transform.position - transform.position).normalized;
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
}
