using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;
    public static bool isPaused;

    public enum GameState
    {
        Play, 
        Upgrade,
        Pause
    }
    
    public GameState CurrentGameState { get; private set; }
    public GameState PreviousGameState { get; private set; }
    
    public static Action<GameState> OnGameStateChange;
    
    private void Start()
    {
        upgradeMenu.SetActive(false);
        isPaused = false;
    }

    public void SetGameState(GameState gameState)
    {
        if (CurrentGameState == gameState) return;
        
        PreviousGameState = CurrentGameState;

        switch (gameState)
        {
            case GameState.Play:
                PlayState();
                break;
            case GameState.Upgrade:
                EnableUpgradeMenu();
                break;
            case GameState.Pause:
                
                break;
            default:
                Debug.LogError($"{gameState} is an invalid movement state!");
                break;
        }
        
        OnGameStateChange?.Invoke(gameState);
        CurrentGameState = gameState;
    }

    private void PlayState()
    {
        if(PreviousGameState == GameState.Upgrade)
        {
            DisableUpgradeMenu();
        }
    }
    
    
    public void EnableUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        GameStateManager.isPaused = true;
    }

    public void DisableUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
        GameStateManager.isPaused = false;
    }
    
    private void PauseGame()
    {
        GameStateManager.isPaused = true;
    }
}
