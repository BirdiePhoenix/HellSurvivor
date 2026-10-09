using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private string upgradeName;
    private float upgradeModifier;
    //Upgradetext for hovering
    //Rarity

    public string UpgradeName
    {
        get => upgradeName;
        set => upgradeName = value;
    }

    public float UpgradeModifier
    {
        get => upgradeModifier;
        set => upgradeModifier = value;
    }
}
