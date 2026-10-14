using System;
using UnityEngine;

public class MGBulletSetup : MonoBehaviour, IBullet
{
    [SerializeField] private string weaponName;
    [SerializeField] private int weaponStorageIndex;
    private bool isReady = false;
    
    [Header("References")]
    private WeaponStorage weaponStorage;
    private IWeapon weapon;
    
    [Header("Weapon Stats")] 
    private float bulletSpeed;
    private float bulletRange;
    private float bulletReloadSpeed;
    private int bulletMagSize;
    private int bulletDamage;

    private void Start()
    {
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        weapon = GameObject.FindGameObjectWithTag(weaponName).GetComponent<IWeapon>();
        
    }

    private void OnEnable()
    {
        if (isReady)
        {
            bulletSpeed = weaponStorage.MgBulletSpeed;
            bulletRange = weaponStorage.MgBulletRange;
            bulletReloadSpeed = weaponStorage.MgBulletReloadSpeed;
            bulletMagSize = weaponStorage.MgBulletMagSize;
            bulletDamage = weaponStorage.MgBulletDamage;
        
            weapon.WeaponReloadSpeed = bulletReloadSpeed;
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
