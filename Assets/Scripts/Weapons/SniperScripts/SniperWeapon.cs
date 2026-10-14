using System.Collections;
using UnityEngine;

public class SniperWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float bulletSpread;
    [SerializeField] private CalculateDistance calculateDistance;
    
    private SniperBulletPool sniperBulletPool;
    private WeaponStorage weaponStorage;
    private Vector2 shootingDirection;

    public Vector2 ShootingDirection
    {
        get => shootingDirection;
        set => shootingDirection = value;
    }

    private void Start()
    {
        sniperBulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<SniperBulletPool>();
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
    }
    
    public void TriggerShooting()
    {
        StartCoroutine(Shoot());
    }
    
    private IEnumerator Shoot()
    {
        ShootingDirection = calculateDistance.CalculateClosestEnemy(true);

        GameObject bullet = sniperBulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        StartCoroutine(DeactivateBullet(bullet));
        
        yield return new WaitForSeconds(weaponStorage.SniperBulletReloadSpeed);
        StartCoroutine(Shoot());
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(weaponStorage.SniperBulletRange);
        sniperBulletPool.ReturnObject(bullet);
    }
}
