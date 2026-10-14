using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour, ISetup
{
    public List<GameObject> weapons;

    [SerializeField] private SO_Bullet mgBulletSO;
    [SerializeField] private GameObject[] weaponIcons;
    private int weaponIndex = 0;

    public int WeaponIndex
    {
        get => weaponIndex;
        set => weaponIndex = value;
    }
    
    // public enum WeaponType
    // {
    //     MachineGun,
    //     ShotGun,
    //     Sniper,
    //     RocketGun
    // }

    private GameObject mgBullet;
    private float mgBulletSpeed;
    private float mgBulletRange;
    private float mgBulletReloadSpeed;
    private int mgBulletMagSize;
    private int mgBulletDamage;

    private void Awake()
    {
        _GameManager.Instance.RegisterDataObjects(this);
    }

    private void Start()
    {
        GetData();
    }

    public void GetData()
    {
        MgBulletSetup();
    }

    // public void SetWeaponType(WeaponType weaponType)
    // {
    //     switch (weaponType)
    //     {
    //         case WeaponType.MachineGun:
    //             MgBulletSetup();
    //             break;
    //         case WeaponType.ShotGun:
    //
    //             break;
    //         case WeaponType.Sniper:
    //             
    //             break;
    //         case WeaponType.RocketGun:
    //             
    //             break;
    //         default:
    //             Debug.LogError($"{weaponType} is an invalid weapon type!");
    //             break;
    //     }
    // }

    private void MgBulletSetup()
    {
        mgBullet = mgBulletSO.BulletPrefab;
        mgBulletSpeed = mgBulletSO.ShootingSpeed;
        mgBulletRange = mgBulletSO.ShootingRange;
        mgBulletReloadSpeed = mgBulletSO.ReloadSpeed;
        mgBulletMagSize = mgBulletSO.MagSize;
        mgBulletDamage = mgBulletSO.Damage;
    }

    public void EnableWeaponIcons()
    {
        weaponIcons[weaponIndex].SetActive(true);
        WeaponIndex++;
        Debug.Log(weaponIndex);
    }

    public GameObject MgBullet
    {
        get => mgBullet;
        set => mgBullet = value;
    }
    
    public float MgBulletSpeed
    {
        get => mgBulletSpeed;
        set => mgBulletSpeed = value;
    }
    
    public float MgBulletRange
    {
        get => mgBulletRange;
        set => mgBulletRange = value;
    }
    
    public float MgBulletReloadSpeed
    {
        get => mgBulletReloadSpeed;
        set => mgBulletReloadSpeed = value;
    }
    
    public int MgBulletMagSize
    {
        get => mgBulletMagSize;
        set => mgBulletMagSize = value;
    }

    public int MgBulletDamage
    {
        get => mgBulletDamage;
        set => mgBulletDamage = value;
    }
}
