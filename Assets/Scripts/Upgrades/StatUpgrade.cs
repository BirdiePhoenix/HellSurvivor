using System;
using UnityEngine;

public class StatUpgrade : MonoBehaviour
{
    [SerializeField] private SO_Upgrade statUpgrade;
    [SerializeField] private float upgradeModifier;
    [SerializeField] private string  upgradeName;

    public StatUpgrade(float _upgradeModifier, string _upgradeName)
    {
        UpgradeModifier = _upgradeModifier;
        UpgradeName = _upgradeName;
    }

    public float UpgradeModifier
    {
        get => upgradeModifier;
        set => upgradeModifier = value;
    }
    
    public string UpgradeName
    {
        get => upgradeName;
        set => upgradeName = value;
    }
}
