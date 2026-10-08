using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    private PlayerSetup playerSetup;
    private WeaponStorage weaponStorage;
    private float upgradeModifier = 1.2f;
    [SerializeField] private Button[] upgradeButtons;
    [SerializeField] private StatUpgrade[] upgradeStatUpgrades;
    private UpgradeButton buttonScript;
    private StatUpgrade statUpgrade;
    
    public enum StatType
    {
        MovementSpeed,
        Damage,
        AttackSpeed,
        Health
    }

    private void AddStatUpgrades()
    {
        
        
    }
    
    private void AssignStatType(StatType statType)
    {
        // switch (statType)
        // {
        //     case StatType.MovementSpeed:
        //         upgradeStatUpgrades[0] = new StatUpgrade(upgradeModifier, "Movement Speed");
        //         break;
        //     case StatType.Damage:
        //         UpgradeName = "Damage";
        //         break;
        //     case StatType.AttackSpeed:
        //         UpgradeName = "Attack Speed";
        //         break;
        //     case StatType.Health:
        //         UpgradeName = "Health";
        //         break;
        // }
    }

    private void SetStatTypes()
    {
        
    }

    public void AddUpgradeToButtons()
    {
        foreach (Button button in upgradeButtons)
        {
            buttonScript = button.GetComponent<UpgradeButton>();
            
        }
    }
    
    
}
