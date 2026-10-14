using System;
using UnityEngine;

public class MGBulletSetup : MonoBehaviour, IBullet
{
    [SerializeField] private int weaponStorageIndex;
    private bool isReady = false;
    
    [Header("References")]
    private WeaponStorage weaponStorage;
    private MGWeapon weapon;
    
    [Header("Weapon Stats")] 
    private float bulletSpeed;
    private float bulletRange;
    private float bulletReloadSpeed;
    private int bulletMagSize;
    private int bulletDamage;

    private void Awake()
    {
        weaponStorage = GameObject.FindGameObjectWithTag("Storage").GetComponent<WeaponStorage>();
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MGWeapon>();
    }
    
    private void Start()
    {
        Debug.Log(weaponStorage.MgBulletName);
    }

    private void OnEnable()
    {
        Debug.Log("Enabled");
        BulletSpeed = weaponStorage.MgBulletSpeed;
        BulletRange = weaponStorage.MgBulletRange;
        BulletReloadSpeed = weaponStorage.MgBulletReloadSpeed;
        BulletMagSize = weaponStorage.MgBulletMagSize;
        BulletDamage = weaponStorage.MgBulletDamage;
        
        weaponStorage.MgBulletReloadSpeed = bulletReloadSpeed;
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
        set => bulletSpeed = value;
    }
    
    public float BulletRange
    {
        get => bulletRange;
        set => bulletRange = value;
    }
    
    public float BulletReloadSpeed
    {
        get => bulletReloadSpeed;
        set => bulletReloadSpeed = value;
    }
    
    public int BulletMagSize
    {
        get => bulletMagSize;
        set => bulletMagSize = value;
    }

    public int BulletDamage
    {
        get => bulletDamage;
        set => bulletDamage = value;
    }
}
