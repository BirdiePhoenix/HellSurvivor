using UnityEngine;

public class SniperBulletBehaviour : MonoBehaviour
{
    private SniperWeapon sniperWeapon;
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
            other.GetComponent<EnemyHealth>().TakeDamage(weaponStorage.SniperBulletDamage);
        }
    }
}
