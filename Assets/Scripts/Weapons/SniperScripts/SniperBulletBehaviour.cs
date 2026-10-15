using UnityEngine;

public class SniperBulletBehaviour : MonoBehaviour
{
    private SniperWeapon sniperWeapon;
    private IObjectPool bulletPool;
    private Rigidbody2D bulletRb;
    private Vector2 shootDirection;
    private WeaponStorage weaponStorage;

    public Vector2 ShootDirection
    {
        get => shootDirection;
        set => shootDirection = value;
    }

    private void Awake()
    {
        bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<SniperBulletPool>();
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        sniperWeapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SniperWeapon>();
    }

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ShootDirection = sniperWeapon.ShootingDirection;
    }

    private void FixedUpdate()
    {
        bulletRb.MovePosition(bulletRb.position + shootDirection * (weaponStorage.SniperBulletSpeed * Time.fixedDeltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(weaponStorage.MgBulletDamage);
        }
    }
}
