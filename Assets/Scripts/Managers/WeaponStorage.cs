using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour
{
    public List<GameObject> weapons;

    [SerializeField] private SO_Bullet mgBulletSO;
    
    private GameObject mgBullet;
    private float mgBulletSpeed;
    private float mgBulletRange;
    private float mgBulletReloadSpeed;
    private int mgBulletMagSize;
    private float mgBulletDamage;

    private void Start()
    {
        mgBullet = mgBulletSO.BulletPrefab;
        mgBulletSpeed = mgBulletSO.ShootingSpeed;
        mgBulletRange = mgBulletSO.ShootingRange;
        mgBulletReloadSpeed = mgBulletSO.ReloadSpeed;
        mgBulletMagSize = mgBulletSO.MagSize;
        mgBulletDamage = mgBulletSO.Damage;
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

    public float MgBulletDamage
    {
        get => mgBulletDamage;
        set => mgBulletDamage = value;
    }
}
