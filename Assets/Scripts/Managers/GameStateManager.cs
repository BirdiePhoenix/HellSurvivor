using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TimeManager timeManager;
    
    [Header("UI Elements")]
    [SerializeField] private GameObject statsUpgradeMenu;
    [SerializeField] private GameObject weaponUpgradeMenu;
    [SerializeField] private GameObject pauseMenu;
    
    public static bool isPaused;

    public enum GameState
    {
        Play, 
        StatsUpgrade,
        WeaponUpgrade,
        Pause
    }
    
    public GameState CurrentGameState { get; private set; }
    public GameState PreviousGameState { get; private set; }
    
    public static Action<GameState> OnGameStateChange;
    
    private void Start()
    {
        statsUpgradeMenu.SetActive(false);
        weaponUpgradeMenu.SetActive(false);
        pauseMenu.SetActive(false);
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
            pauseMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }
}
