using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{   //Controls the canvases depending on what game state the game is in
    [Header("References")]
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private HighScoreManager highScoreManager;
    
    [Header("UI Elements")]
    [SerializeField] private GameObject statsUpgradeMenu;
    [SerializeField] private GameObject weaponUpgradeMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;

    private static bool isPaused;

    public enum GameState
    {
        Play, 
        StatsUpgrade,
        WeaponUpgrade,
        Pause,
        GameOver
    }
    
    public GameState CurrentGameState { get; private set; }
    public GameState PreviousGameState { get; private set; }
    
    public static Action<GameState> OnGameStateChange;
    
    private void Start()
    {
        statsUpgradeMenu.SetActive(false);
        weaponUpgradeMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        isPaused = false;
    }

    public void SetGameState(GameState gameState)
    {
        if (CurrentGameState == gameState) return;
        
        PreviousGameState = CurrentGameState;

        switch (gameState)
        {
            case GameState.Play:
                timeManager.ResumeTime();
                HandlePlayState();
                break;
            case GameState.StatsUpgrade:
                timeManager.PauseTime();
                HandelStatsUpgradeState();
                break;
            case GameState.WeaponUpgrade:
                timeManager.PauseTime();
                HandleWeaponUpgradeState();
                break;
            case GameState.Pause:
                timeManager.PauseTime();
                HandlePauseState();
                break;
            case GameState.GameOver:
                timeManager.PauseTime();
                HandleGameOverState();
                break;
            default:
                Debug.LogError($"{gameState} is an invalid movement state!");
                break;
        }
        
        OnGameStateChange?.Invoke(gameState);
        CurrentGameState = gameState;
    }

    private void HandlePlayState()
    {
        if(PreviousGameState == GameState.StatsUpgrade)
        {
            HandelStatsUpgradeState();
        }
        else if (PreviousGameState == GameState.WeaponUpgrade)
        {
            HandleWeaponUpgradeState();
        }
        else if (PreviousGameState == GameState.Pause)
        {
            HandlePauseState();
        }
        else if (PreviousGameState == GameState.GameOver)
        {
            HandleGameOverState();
        }
    }
    
    
    public void HandelStatsUpgradeState()
    {
        if (!isPaused)
        {
            statsUpgradeMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            statsUpgradeMenu.SetActive(false);
            isPaused = false;
        }
    }

    private void HandleWeaponUpgradeState()
    {
        if (!isPaused)
        {
            weaponUpgradeMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            weaponUpgradeMenu.SetActive(false);
            isPaused = false;
        }
    }
    
    private void HandlePauseState()
    {
        if (!isPaused)
        {
            highScoreManager.UpdateHighScore(highScoreManager.CurrentScore);
            pauseMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    private void HandleGameOverState()
    {
        if (PreviousGameState != GameState.GameOver)
        {
            gameOverMenu.SetActive(true);
            gameOverManager.GameOver();
        }
        else
        {
            gameOverMenu.SetActive(false);
        }
    }
}
