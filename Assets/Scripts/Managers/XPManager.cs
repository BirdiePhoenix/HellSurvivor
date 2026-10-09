using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    private PlayerSetup playerSetup;
    [SerializeField] private float xpGrowthMultiplier = 1.2f;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TMP_Text currentLvlText;
    [SerializeField] UIManager uiManager;
    [SerializeField] UpgradeManager upgradeManager;

    void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
        UpdateXpUI();
    }

    public void GainXp(int xpValue)
    {
        playerSetup.CurrentXp += xpValue;
        if(playerSetup.CurrentXp >= playerSetup.CurrentMaxXp)
        {
            LevelUp();
        }
        UpdateXpUI();
    }

    private void LevelUp()
    {
        playerSetup.CurrentXp++;
        playerSetup.CurrentXp = 0;
        playerSetup.CurrentMaxXp = Mathf.RoundToInt(playerSetup.CurrentMaxXp * xpGrowthMultiplier);
        playerSetup.CurrentLvl++;
        upgradeManager.ButtonSetUp();
        uiManager.EnableUpgradeMenu();
    }
    
    private void UpdateXpUI()
    {
        uiManager.UpdateUI(xpSlider, playerSetup.CurrentMaxXp, playerSetup.CurrentXp);
        currentLvlText.text = $"Level {playerSetup.CurrentLvl}";
    }
    
    
}
