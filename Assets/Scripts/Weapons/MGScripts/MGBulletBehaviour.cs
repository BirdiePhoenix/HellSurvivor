using System;
using UnityEngine;

public class MGBulletBehaviour : MonoBehaviour
{
    [SerializeField] private MGBulletSetup mgBulletSetup;
    private MGWeapon mgWeapon;
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
        bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<MGBulletPool>();
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        mgWeapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MGWeapon>();
    }

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ShootDirection = mgWeapon.ShootingDirection;
    }

    private void FixedUpdate()
    {
        bulletRb.MovePosition(bulletRb.position + shootDirection * (weaponStorage.MgBulletSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            bulletPool.ReturnObject(gameObject);
            other.GetComponent<EnemyHealth>().TakeDamage(mgBulletSetup.BulletDamage);
        }
    }
}
