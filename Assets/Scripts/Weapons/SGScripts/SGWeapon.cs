using System.Collections;
using UnityEngine;

public class SGWeapon : MonoBehaviour, IWeapon
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

    public void TriggerShooting()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        /// The spread should be 45 degrease both up and down, 45+45=90. We then devide with amount of bullets in mag.
        /// Since one bullet is at z=0 we needs to remove with 1
        float zSpread = 90 / (float)(weaponStorage.MgBulletMagSize - 1);
        float zRotation = 45f;
        for (int i = 0; i < weaponStorage.MgBulletMagSize; i++)
        {
            GameObject bullet = sgBulletPool.GetObject();
            this.transform.rotation = Quaternion.Euler(0, 0, zRotation);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            StartCoroutine(DeactivateBullet(bullet));
            zRotation -= zSpread;
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
