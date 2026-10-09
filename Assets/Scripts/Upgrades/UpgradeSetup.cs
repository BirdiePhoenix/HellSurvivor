using UnityEngine;

public class UpgradeSetup : MonoBehaviour
{
    [SerializeField] private SO_Upgrade soUpgrade;
    private string upgradeName;
    private float upgradeModifier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpgradeName = soUpgrade.UpgradeName;
        UpgradeModifier = soUpgrade.UpgradeModifier;
    }

    public string UpgradeName { get; set; }
    public float UpgradeModifier { get; set; }
}
