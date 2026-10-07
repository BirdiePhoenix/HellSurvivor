using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    private PlayerSetup playerSetup;
    [SerializeField] private float xpGrowthMultiplier = 1.2f;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TMP_Text currentLvlText;

    void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
        UpdateUI();
    }

    public void GainXp(int xp)
    {
        playerSetup.CurrentXp += xp;
        if(playerSetup.CurrentXp >= playerSetup.CurrentMaxXp)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        playerSetup.CurrentXp++;
        playerSetup.CurrentXp = 0;
        playerSetup.CurrentMaxXp = Mathf.RoundToInt(playerSetup.CurrentMaxXp * xpGrowthMultiplier);
        playerSetup.CurrentLvl++;
    }
    
    private void UpdateUI()
    {
        xpSlider.maxValue = playerSetup.CurrentMaxXp;
        xpSlider.value = playerSetup.CurrentXp;
        currentLvlText.text = $"Level {playerSetup.CurrentLvl}";
    }
}
