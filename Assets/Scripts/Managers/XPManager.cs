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
    [SerializeField] private int thirdWeapon = 30;

    [Header("EnemyStages")] 
    [SerializeField] private int stage2Lvl = 8;
    [SerializeField] private int stage3Lvl = 15;
    
    [Header("References")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private HighScoreManager highScoreManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private _EnemySpawner enemySpawner;
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
        enemySpawner.IncreaseSpawning();

        if (playerSetup.CurrentLvl == firstWeapon || playerSetup.CurrentLvl == secondWeapon ||
            playerSetup.CurrentLvl == thirdWeapon)
        {
            AddWeapon();
        }
        else
        {
            AddStat();
        }

        if (playerSetup.CurrentLvl == stage2Lvl)
        {
            enemySpawner.SetEnemyStage(_EnemySpawner.EnemyStage.Stage2);
        }
        else if (playerSetup.CurrentLvl == stage3Lvl)
        {
            enemySpawner.SetEnemyStage(_EnemySpawner.EnemyStage.Stage3);
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
        uiManager.UpdateUI(xpSlider, playerSetup.CurrentMaxXp, playerSetup.CurrentXp);
        currentLvlText.text = $"Level {playerSetup.CurrentLvl}";
    }
}
