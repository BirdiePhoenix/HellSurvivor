using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider hpSlider;
  
    [Header("Text")]
    [SerializeField] private TMP_Text currentHpText;
    private string hpText;
    private PlayerSetup playerSetup;
    
    void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
        UpdateHpUI();
    }

    public void UpdateHealth(int healthValue)
    {
        playerSetup.CurrentHealth += healthValue;
        if (playerSetup.CurrentHealth <= 0)
        {
            playerSetup.CurrentHealth = 0;
        }
        UpdateHpUI();
    }

    public void UpdateMaxHealth(float hpGrowthMultiplierValue)
    {
        playerSetup.CurrentMaxHealth = Mathf.RoundToInt(playerSetup.CurrentMaxHealth * hpGrowthMultiplierValue);
        playerSetup.CurrentHealth = Mathf.RoundToInt(playerSetup.CurrentHealth * hpGrowthMultiplierValue);
        UpdateHpUI();
    }
    
    private void UpdateHpUI()
    {
        hpSlider.maxValue = playerSetup.CurrentMaxHealth;
        hpSlider.value = playerSetup.CurrentHealth;
        currentHpText.text = $"{playerSetup.CurrentHealth}/{playerSetup.CurrentMaxHealth}";
    }
}
