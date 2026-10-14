using System;
using UnityEngine;

public class BulletSetup : MonoBehaviour
{
    private WeaponStorage weaponStorage;
    private MGWeapon mgWeapon;
    
    private float bulletSpeed;
    private float bulletRange;
    private float bulletReloadSpeed;
    private int bulletMagSize;
    private int bulletDamage;

    private void Start()
    {
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        mgWeapon = GameObject.FindGameObjectWithTag("MGWeapon").GetComponent<MGWeapon>();
        bulletSpeed = weaponStorage.MgBulletSpeed;
        bulletRange = weaponStorage.MgBulletRange;
        bulletReloadSpeed = weaponStorage.MgBulletReloadSpeed;
        bulletMagSize = weaponStorage.MgBulletMagSize;
        bulletDamage = weaponStorage.MgBulletDamage;
        
        mgWeapon.WeaponReloadSpeed = bulletReloadSpeed;
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
