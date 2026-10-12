using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour
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

    private GameObject mgBullet;
    private float mgBulletSpeed;
    private float mgBulletRange;
    private float mgBulletReloadSpeed;
    private int mgBulletMagSize;
    private int mgBulletDamage;

    private void Start()
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
