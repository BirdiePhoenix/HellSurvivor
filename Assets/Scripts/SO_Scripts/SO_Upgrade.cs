using UnityEngine;

[CreateAssetMenu(fileName = "SO_Upgrade", menuName = "Scriptable Objects/SO_Upgrade")]
public class SO_Upgrade : ScriptableObject
{
    [SerializeField] private string upgradeName;
    [SerializeField] private float upgradeModifier;
    [SerializeField] private int enumInt;
    
    public string UpgradeName { get => upgradeName; }
    public float UpgradeModifier { get => upgradeModifier;}
    public int EnumInt { get => enumInt; }
}
