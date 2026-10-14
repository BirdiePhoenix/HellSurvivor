using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour, ISetup
{
    
    [Header("BulletStats")]
    [SerializeField] private SO_Bullet mgBulletSO;
    [SerializeField] private SO_Bullet sgBulletSO;
    [SerializeField] private SO_Bullet sniperBulletSO;
    
    [Header("WeaponIcons")]
    [SerializeField] private GameObject[] weaponIcons;
    [SerializeField] private GameObject[] weapons;
    private int weaponIndex = 0;

    [Header("References")] 
    private GameObject player;
    private GameObject sgWeapon;
    private GameObject sniperWeapon;
    private GameObject rgWeapon;

    public int WeaponIndex
    {
        get => weaponIndex;
        set => weaponIndex = value;
    }

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
    
    [Header("Sniper")]
    private GameObject sniperBullet;
    private string sniperBulletName;
    private float sniperBulletSpeed;
    private float sniperBulletRange;
    private float sniperBulletReloadSpeed;
    private int sniperBulletMagSize;
    private int sniperBulletDamage;

    private void Awake()
    {
        _GameManager.Instance.RegisterDataObjects(this);
        GetData();
    }

    private void Start()
    {
        sgWeapon = GameObject.FindGameObjectWithTag("SGWeapon");
        weapons[0] = sgWeapon;
        sniperWeapon = GameObject.FindGameObjectWithTag("SniperWeapon");
        weapons[1] = sniperWeapon;
        rgWeapon = GameObject.FindGameObjectWithTag("RGWeapon");
        weapons[2] = rgWeapon;

        foreach (GameObject w in weapons)
        {
            w.SetActive(false);
        }

    }

    public void GetData()
    {
        MgBulletSetup();
        SgBulletSetup();
        SniperBulletSetup();
    }

    public void EnableWeaponIcons()
    {
        weaponIcons[weaponIndex].SetActive(true);
        Debug.Log(weaponIndex);
    }

    public void EnableWeapons()
    {
        weapons[weaponIndex].SetActive(true);
        weapons[weaponIndex].GetComponent<IWeapon>().TriggerShooting();
        WeaponIndex++;
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
    
    private void SniperBulletSetup()
    {
        SniperBulletSpeed = sniperBulletSO.ShootingSpeed;
        SniperBulletRange = sniperBulletSO.ShootingRange;
        SniperBulletReloadSpeed = sniperBulletSO.ReloadSpeed;
        SniperBulletMagSize = sniperBulletSO.MagSize;
        SniperBulletDamage = sniperBulletSO.Damage;
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
        #region SniperBullet
        public string SniperBulletName
        {
            get => sniperBulletName;
            set => sniperBulletName = value;
        }
    
        public float SniperBulletSpeed
        {
            get => sniperBulletSpeed;
            set => sniperBulletSpeed = value;
        }
    
        public float SniperBulletRange
        {
            get => sniperBulletRange;
            set => sniperBulletRange = value;
        }
    
        public float SniperBulletReloadSpeed
        {
            get => sniperBulletReloadSpeed;
            set => sniperBulletReloadSpeed = value;
        }
    
        public int SniperBulletMagSize
        {
            get => sniperBulletMagSize;
            set => sniperBulletMagSize = value;
        }

        public int SniperBulletDamage
        {
            get => sniperBulletDamage;
            set => sniperBulletDamage = value;
        }
        #endregion
    #endregion
    
}
