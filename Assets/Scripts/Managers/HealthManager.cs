using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private PlayerSetup playerSetup;
    [SerializeField] private float hpGrowthMultiplier = 1.2f;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TMP_Text currentHpText;
    
    void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
        UpdateUI();
    }

    public void UpdateHealth(int healthValue)
    {
        playerSetup.CurrentHealth += healthValue;
        UpdateUI();
    }

    public void UpdateMaxHealth(float hpGrowthMultiplier)
    {
        playerSetup.CurrentMaxXp = Mathf.RoundToInt(playerSetup.CurrentMaxXp * hpGrowthMultiplier);
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        hpSlider.maxValue = playerSetup.CurrentMaxHealth;
        hpSlider.value = playerSetup.CurrentHealth;
        currentHpText.text = $"{playerSetup.CurrentHealth}/{playerSetup.CurrentMaxHealth}";
    }
}
