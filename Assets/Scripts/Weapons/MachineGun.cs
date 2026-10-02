using System;
using System.Collections;
using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        WeaponBehaviour();
    }

    protected override void WeaponBehaviour()
    {
        for (int i = 0; i < bulletType.MagSize; i++)
        {
            
        }
    }

    
}
