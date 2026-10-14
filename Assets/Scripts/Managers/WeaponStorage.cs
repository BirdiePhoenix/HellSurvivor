using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour, ISetup
{
    public List<GameObject> weapons;
    
    [Header("BulletStats")]
    [SerializeField] private SO_Bullet mgBulletSO;
    [SerializeField] private SO_Bullet sgBulletSO;
    // [SerializeField] private SO_Bullet mgBulletSO;
    // [SerializeField] private SO_Bullet mgBulletSO;
    
    [Header("WeaponIcons")]
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

    [Header("MachineGun")]
    private GameObject mgBullet;
    private string mgBulletName;
    private float mgBulletSpeed;
    private float mgBulletRange;
    private float mgBulletReloadSpeed;
    private int mgBulletMagSize;
    private int mgBulletDamage;
    
    [Header("ShotGun")]
    private GameObject sgBullet;
    private string sgBulletName;
    private float sgBulletSpeed;
    private float sgBulletRange;
    private float sgBulletReloadSpeed;
    private int sgBulletMagSize;
    private int sgBulletDamage;

    private void Awake()
    {
        _GameManager.Instance.RegisterDataObjects(this);
        GetData();
    }

    private void Start()
    {
        
    }

    public void GetData()
    {
        MgBulletSetup();
        SgBulletSetup();
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

    public void EnableWeaponIcons()
    {
        weaponIcons[weaponIndex].SetActive(true);
        WeaponIndex++;
        Debug.Log(weaponIndex);
    }
    
    #region BulletSetups

    private void MgBulletSetup()
    {
        MgBulletName = mgBulletSO.BulletName;
        MgBulletSpeed = mgBulletSO.ShootingSpeed;
        MgBulletRange = mgBulletSO.ShootingRange;
        MgBulletReloadSpeed = mgBulletSO.ReloadSpeed;
        MgBulletMagSize = mgBulletSO.MagSize;
        MgBulletDamage = mgBulletSO.Damage;
    }
    
    private void SgBulletSetup()
    {
        SgBulletName = sgBulletSO.BulletName;
        SgBulletSpeed = sgBulletSO.ShootingSpeed;
        SgBulletRange = sgBulletSO.ShootingRange;
        SgBulletReloadSpeed = sgBulletSO.ReloadSpeed;
        SgBulletMagSize = sgBulletSO.MagSize;
        SgBulletDamage = sgBulletSO.Damage;
    }

    #endregion

    #region Bullet Properties
        #region MachinegunBullet

    public GameObject MgBullet
    {
        get => mgBullet;
        set => mgBullet = value;
    }

    public string MgBulletName
    {
        get => mgBulletName;
        set => mgBulletName = value;
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
        #endregion
        #region ShotgunBullet
    public GameObject SgBullet
    {
        get => sgBullet;
        set => sgBullet = value;
    }

    public string SgBulletName
    {
        get => sgBulletName;
        set => sgBulletName = value;
    }
    
    public float SgBulletSpeed
    {
        get => sgBulletSpeed;
        set => sgBulletSpeed = value;
    }
    
    public float SgBulletRange
    {
        get => sgBulletRange;
        set => sgBulletRange = value;
    }
    
    public float SgBulletReloadSpeed
    {
        get => sgBulletReloadSpeed;
        set => sgBulletReloadSpeed = value;
    }
    
    public int SgBulletMagSize
    {
        get => sgBulletMagSize;
        set => sgBulletMagSize = value;
    }

    public int SgBulletDamage
    {
        get => sgBulletDamage;
        set => sgBulletDamage = value;
    }
        #endregion
    #endregion
    
}
