using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;

    public void OnResumeButtonClick()
    {
        gameStateManager.SetGameState(GameStateManager.GameState.Play);
    }
}
