using UnityEngine;

public class SGBulletBehaviour : MonoBehaviour
{
    [SerializeField] private SGBulletSetup sgBulletSetup;
    private IWeapon weapon;
    private IObjectPool bulletPool;
    private Rigidbody2D bulletRb;
    private Vector2 shootDirection;
    private WeaponStorage weaponStorage;

    public Vector2 ShootDirection
    {
        get => shootDirection;
        set => shootDirection = value;
    }

    private bool isReady = false;
    private void Start()
    {
        //bulletPool = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<MGBulletPool>();
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        weapon = GameObject.FindGameObjectWithTag(weaponStorage.SgBulletName).GetComponent<IWeapon>();
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (isReady)
        {
            shootDirection = weapon.ShootingDirection;
        }
    }

    private void OnDisable()
    {
        isReady = true;
    }

    private void FixedUpdate()
    {
        bulletRb.MovePosition(bulletRb.position + shootDirection * (sgBulletSetup.BulletSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            bulletPool.ReturnObject(gameObject);
            other.GetComponent<EnemyHealth>().TakeDamage(sgBulletSetup.BulletDamage);
        }
    }
}
