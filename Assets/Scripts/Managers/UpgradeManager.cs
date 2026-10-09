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
    
    [Header("Upgrade Buttons")]
    [SerializeField] private Button[] buttons;
    private List<UpgradeSetup> availableUpgrades;
    
    [Header("Upgrade Types")]
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private PlayerSetup playerSetup;

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
    }

    public void UpgradeMovementSpeed()
    {
        Debug.Log("MovementSpeed");
    }

    public void UpgradeReloadSpeed()
    {
        Debug.Log("ReloadSpeed");
    }

    public void UpgradeBulletDamage()
    {
        Debug.Log("BulletDamage");
    }
    
}
