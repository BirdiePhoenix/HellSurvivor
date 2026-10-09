using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private TMP_Text upgradeName;
    [SerializeField] UIManager uiManager;

    private float upgrademodifier;

    public float UpgradeModifier
    {
        get => upgrademodifier;
        set => upgrademodifier = value;
    }
    
    private string upgradeType;

    public string UpgradeType
    {
        get => upgradeType;
        set => upgradeType = value;
    }

    public void OnButtonClick()
    {
        UpgradeStats();
        uiManager.DisableUpgradeMenu();
    } 
    
    public void UpgradeStats()
    {
        switch (UpgradeType)
        {
            case "Health":
                upgradeManager.UpgradeMaxHealth();
                break;
            case "Movement Speed":
                upgradeManager.UpgradeMovementSpeed();
                break;
            case "Reload Speed":
                upgradeManager.UpgradeReloadSpeed();
                break;
            case "Bullet Damage":
                upgradeManager.UpgradeBulletDamage();
                break;
        }
    }
}
