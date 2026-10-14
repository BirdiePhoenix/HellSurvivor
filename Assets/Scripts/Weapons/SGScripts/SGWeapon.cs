using System.Collections;
using UnityEngine;

public class SGWeapon : MonoBehaviour
{
    [SerializeField] private DirectionState directionState;
    [SerializeField] private SGBulletPool sgBulletPool;
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
        yield return new WaitForSeconds(weaponStorage.SgBulletReloadSpeed);
    }
    
    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(weaponStorage.SgBulletRange);
        sgBulletPool.ReturnObject(bullet);
    }
}
