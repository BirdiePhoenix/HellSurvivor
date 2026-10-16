using System;
using UnityEngine;

public class WeaponStageManager : MonoBehaviour
{
    public enum WeaponStage
    {
        MG,
        SG,
        Sniper,
        RG
    }
    
    public WeaponStage CurrentWeaponStage { get; private set; }
    
    public void SetWeaponStage(WeaponStage weaponStage)
    {
        if (weaponStage == CurrentWeaponStage) return;
        CurrentWeaponStage = weaponStage;
    }
}
