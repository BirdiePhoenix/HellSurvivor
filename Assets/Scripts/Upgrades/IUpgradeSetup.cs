using UnityEngine;

public interface IUpgradeSetup
{
    void SetStats();
    float UpgradeModifier { get; set; }
    int EnumInt { get; set; }
}
