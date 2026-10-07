using System;
using UnityEngine;

public class BulletSetup : MonoBehaviour
{
    private WeaponStorage weaponStorage;
    private FireProjectile fireProjectile;
    
    private float bulletSpeed;
    private float bulletRange;
    private float bulletReloadSpeed;
    private int bulletMagSize;
    private float bulletDamage;

    private void Start()
    {
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        fireProjectile = GameObject.FindGameObjectWithTag("MGWeapon").GetComponent<FireProjectile>();
        bulletSpeed = weaponStorage.MgBulletSpeed;
        bulletRange = weaponStorage.MgBulletRange;
        bulletReloadSpeed = weaponStorage.MgBulletReloadSpeed;
        bulletMagSize = weaponStorage.MgBulletMagSize;
        bulletDamage = weaponStorage.MgBulletDamage;
        
        fireProjectile.WeaponReloadSpeed = bulletReloadSpeed;
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

    public float BulletDamage
    {
        get => bulletDamage;
    }
}
