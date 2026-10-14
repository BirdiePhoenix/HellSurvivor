using System;
using System.Collections;
using UnityEngine;

public class MachineGun : MonoBehaviour, IWeapon
{
    [SerializeField] private SO_Bullet bulletType;
    [SerializeField] private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        WeaponBehaviour();
    }

    public void WeaponBehaviour()
    {
        for (int i = 0; i < bulletType.MagSize; i++)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        Instantiate(bulletType.BulletPrefab);
        yield return new WaitForSecondsRealtime(bulletType.ShootingSpeed);
    }
}
