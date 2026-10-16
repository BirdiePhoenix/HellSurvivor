using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private float xpGrowthMultiplier = 1.2f;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TMP_Text currentLvlText;
    
    [Header("Weapons")]
    [SerializeField] private int firstWeapon = 10;
    [SerializeField] private int secondWeapon = 20;

    [Header("EnemyStages")] 
    [SerializeField] private int stage2Lvl = 8;
    
    [Header("References")]
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private HighScoreManager highScoreManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private WeaponStorage weaponStorage;
    private PlayerSetup playerSetup;

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
        highScoreManager.UpdateScore(100);

        if (playerSetup.CurrentLvl == firstWeapon || playerSetup.CurrentLvl == secondWeapon) //If level is at level for unlocking weapon
        {
            AddWeapon();
        }
        else
        {
            AddStat();
        }

        if (playerSetup.CurrentLvl == firstWeapon)
        {
            weaponStorage.SetWeaponStage(WeaponStorage.WeaponStage.SG);
        }
        else if (playerSetup.CurrentLvl == secondWeapon)
        {
            weaponStorage.SetWeaponStage(WeaponStorage.WeaponStage.Sniper);
        }

        if (playerSetup.CurrentLvl == stage2Lvl)
        {
            enemySpawner.SetEnemyStage(EnemySpawner.EnemyStage.Stage2);
        }
    }

    private void AddWeapon()
    {
        gameStateManager.SetGameState(GameStateManager.GameState.WeaponUpgrade);
    }

    private void AddStat()
    {
        upgradeManager.StatsButtonSetUp();
        gameStateManager.SetGameState(GameStateManager.GameState.StatsUpgrade);
    }
    
    private void UpdateXpUI()
    {
        xpSlider.maxValue = playerSetup.CurrentMaxXp;
        xpSlider.value = playerSetup.CurrentXp;
        currentLvlText.text = $"Level {playerSetup.CurrentLvl}";
    }
}
