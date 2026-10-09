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
        ButtonSetUp();
    }

    public void ButtonSetUp()
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
        Debug.Log("ReloadSpeed");
        weaponStorage.MgBulletReloadSpeed *= upgradeList[2].UpgradeModifier;
        Debug.Log(weaponStorage.MgBulletReloadSpeed);
    }

    public void UpgradeBulletDamage()
    {
        Debug.Log("BulletDamage");
        weaponStorage.MgBulletDamage = Mathf.RoundToInt(weaponStorage.MgBulletDamage * upgradeList[3].UpgradeModifier);
    }
    
}
