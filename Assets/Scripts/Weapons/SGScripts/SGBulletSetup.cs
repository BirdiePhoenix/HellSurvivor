using UnityEngine;

public class SGBulletSetup : MonoBehaviour, IBullet
{
    [SerializeField] private int weaponStorageIndex;
    private bool isReady = false;
    
    [Header("References")]
    private WeaponStorage weaponStorage;
    private SGWeapon sgWeapon;
    
    [Header("Weapon Stats")] 
    private float bulletSpeed;
    private float bulletRange;
    private float bulletReloadSpeed;
    private int bulletMagSize;
    private int bulletDamage;

    private void Start()
    {
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        //sgWeapon = GameObject.FindGameObjectWithTag(weaponStorage.SgBulletName).GetComponent<IWeapon>();
        
    }

    private void OnEnable()
    {
        if (isReady)
        {
            bulletSpeed = weaponStorage.SgBulletSpeed;
            bulletRange = weaponStorage.SgBulletRange;
            bulletReloadSpeed = weaponStorage.SgBulletReloadSpeed;
            bulletMagSize = weaponStorage.SgBulletMagSize;
            bulletDamage = weaponStorage.SgBulletDamage;
        
            //sgWeapon.WeaponReloadSpeed = bulletReloadSpeed;
        }
    }

    private void OnDisable()
    {
        if (!isReady)
        {
            isReady = true;
        }
    }

    public float BulletSpeed
    {
        get => bulletSpeed;
    }
    
    public float BulletRange
    {
        get => bulletRange;
    }
    
    public float BulletReloadSpeed
    {
        get => bulletReloadSpeed;
    }
    
    public int BulletMagSize
    {
        get => bulletMagSize;
    }

    public int BulletDamage
    {
        get => bulletDamage;
    }
}
