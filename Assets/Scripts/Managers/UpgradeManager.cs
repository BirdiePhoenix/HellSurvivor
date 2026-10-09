using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class UpgradeManager : MonoBehaviour
{
    [Header("Upgrade Settings")]
    [SerializeField] private SO_Upgrade[] upgradeList;
    
    [Header("Upgrade Buttons")]
    [SerializeField] private Button[] buttons;
    private List<SO_Upgrade> availableUpgrades;
    
    [Header("Upgrade Types")]
    [SerializeField] private HealthManager healthManager;

    private void Start()
    {
        ButtonSetUp();
    }

    public void ButtonSetUp()
    {
        availableUpgrades = new List<SO_Upgrade>();
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
            availableUpgrades.RemoveAt(rndmNum);
        }
    }

    public void UpgradeMaxHealth()
    {
        
    }
    
}
