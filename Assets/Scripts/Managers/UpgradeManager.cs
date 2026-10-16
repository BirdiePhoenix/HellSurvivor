using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class UpgradeManager : MonoBehaviour
{
    [Header("Upgrade Settings")]
    [SerializeField] private UpgradeSetup[] upgradeList;
    private UpgradeSetup currentUpgradeSetup;
    
    [Header("Upgrade Buttons")]
    [SerializeField] private Button[] buttons;
    private List<UpgradeSetup> availableUpgrades;
    
    [Header("Upgrade Targets")]
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private WeaponStorage weaponStorage;

    private void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
        StatsButtonSetUp();
    }

    public void StatsButtonSetUp()
    {
        availableUpgrades = new List<UpgradeSetup>();
        for (int i = 0; i < upgradeList.Length; i++)
        {
            availableUpgrades.Add(upgradeList[i]);
        }

        foreach (Button button in buttons)
        {
            if (availableUpgrades == null || availableUpgrades.Count <= 0)
            {
                Debug.Log("The list is empty or null!");
                return;
            }
            int rndmNum = (int)UnityEngine.Random.Range(0, availableUpgrades.Count);
            
            button.GetComponentInChildren<TextMeshProUGUI>().text = availableUpgrades[rndmNum].UpgradeName;
            button.GetComponent<UpgradeButton>().UpgradeType = availableUpgrades[rndmNum].UpgradeName;
            availableUpgrades.RemoveAt(rndmNum);
        }
    }

    public void UpgradeMaxHealth()
    {
        Debug.Log("Health"); 
        healthManager.UpdateMaxHealth(upgradeList[0].UpgradeModifier);
        Debug.Log(playerSetup.CurrentMaxHealth);
    }

    public void UpgradeMovementSpeed()
    {
        Debug.Log("MovementSpeed");
        playerSetup.CurrentMovementSpeed *=  upgradeList[1].UpgradeModifier;
        Debug.Log(playerSetup.CurrentMovementSpeed);
    }

    public void UpgradeReloadSpeed()
    {
        switch (weaponStorage.CurrentWeaponStage)
        {
            case WeaponStorage.WeaponStage.MG:
                weaponStorage.MgBulletReloadSpeed *= upgradeList[2].UpgradeModifier;
                break;
            case WeaponStorage.WeaponStage.SG:
                weaponStorage.MgBulletReloadSpeed *= upgradeList[2].UpgradeModifier;
                weaponStorage.SgBulletReloadSpeed *= upgradeList[2].UpgradeModifier;
                break;
            case WeaponStorage.WeaponStage.Sniper:
                weaponStorage.MgBulletReloadSpeed *= upgradeList[2].UpgradeModifier;
                weaponStorage.SgBulletReloadSpeed *= upgradeList[2].UpgradeModifier;
                weaponStorage.SniperBulletReloadSpeed *= upgradeList[2].UpgradeModifier;
                break;
            default:
                Debug.LogError($"{weaponStorage.CurrentWeaponStage} isn't a valid weapon stage!");
                break;
        }
        
        
    }

    public void UpgradeBulletDamage()
    {
        switch (weaponStorage.CurrentWeaponStage)
        {
            case WeaponStorage.WeaponStage.MG:
                weaponStorage.MgBulletDamage = Mathf.RoundToInt(weaponStorage.MgBulletDamage * upgradeList[3].UpgradeModifier);
                break;
            case WeaponStorage.WeaponStage.SG:
                weaponStorage.MgBulletDamage = Mathf.RoundToInt(weaponStorage.MgBulletDamage * upgradeList[3].UpgradeModifier);
                weaponStorage.SgBulletDamage = Mathf.RoundToInt(weaponStorage.SgBulletDamage * upgradeList[3].UpgradeModifier);
                break;
            case WeaponStorage.WeaponStage.Sniper:
                weaponStorage.MgBulletDamage = Mathf.RoundToInt(weaponStorage.MgBulletDamage * upgradeList[3].UpgradeModifier);
                weaponStorage.SgBulletDamage = Mathf.RoundToInt(weaponStorage.SgBulletDamage * upgradeList[3].UpgradeModifier);
                weaponStorage.SniperBulletDamage = Mathf.RoundToInt(weaponStorage.SgBulletDamage * upgradeList[3].UpgradeModifier);
                break;
            default:
                Debug.LogError($"{weaponStorage.CurrentWeaponStage} isn't a valid weapon stage!");
                break;
        }
        
        Debug.Log("BulletDamage");
        
    }
}
