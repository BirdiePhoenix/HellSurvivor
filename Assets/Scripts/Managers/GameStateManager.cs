using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject pauseMenu;
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
                HandlePlayState();
                break;
            case GameState.Upgrade:
                HandelUpgradeState();
                break;
            case GameState.Pause:
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
        if(PreviousGameState == GameState.Upgrade)
        {
            HandelUpgradeState();
        }
        else if (PreviousGameState == GameState.Pause)
        {
            HandlePauseState();
        }
    }
    
    
    public void HandelUpgradeState()
    {
        if (!isPaused)
        {
            upgradeMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            upgradeMenu.SetActive(false);
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
