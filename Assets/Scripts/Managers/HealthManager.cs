using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private PlayerSetup playerSetup;
    [SerializeField] private float hpGrowthMultiplier = 1.2f;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TMP_Text currentHpText;
    private string hpText;
    [SerializeField] UIManager uiManager;
    
    void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
        UpdateHpUI();
    }

    public void UpdateHealth(int healthValue)
    {
        playerSetup.CurrentHealth += healthValue;
        UpdateHpUI();
    }

    public void UpdateMaxHealth(float hpGrowthMultiplierValue)
    {
        playerSetup.CurrentMaxXp = Mathf.RoundToInt(playerSetup.CurrentMaxXp * hpGrowthMultiplierValue);
        UpdateHpUI();
    }
    
    private void UpdateHpUI()
    {
        uiManager.UpdateUI(hpSlider, playerSetup.CurrentMaxHealth, playerSetup.CurrentHealth);
        currentHpText.text = $"{playerSetup.CurrentHealth}/{playerSetup.CurrentMaxHealth}";
    }
}
