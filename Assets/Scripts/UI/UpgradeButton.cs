using Unity.VisualScripting;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;

    private float upgrademodifier;

    public float UpgradeModifier
    {
        get => upgrademodifier;
        set => upgrademodifier = value;
    }
    public enum UpgradeType
    {
        Health,
        MovementSpeed,
        ReloadSpeed,
        BulletDamage
    }
    
    public UpgradeType ChosenUpgradeType { get; private set; }

    public void OnButtonClick()
    {
        UpgradeStats(ChosenUpgradeType);
    } 
    
    private void UpgradeStats(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.Health:
                
                break;
            case UpgradeType.MovementSpeed:
                
                break;
            case UpgradeType.ReloadSpeed:
                
                break;
            case UpgradeType.BulletDamage:
                
                break;
        }
    }
}
