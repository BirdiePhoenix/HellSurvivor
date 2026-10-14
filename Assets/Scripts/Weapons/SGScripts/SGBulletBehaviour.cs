using UnityEngine;

public class SGBulletBehaviour : MonoBehaviour
{
    [SerializeField] private SGBulletSetup sgBulletSetup;
    private SGWeapon sgWeapon;
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
        sgWeapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SGWeapon>();
    }
    
    private bool isReady = false;
    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (isReady)
        {
            shootDirection = sgWeapon.ShootingDirection;
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
