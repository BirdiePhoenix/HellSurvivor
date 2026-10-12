using UnityEngine;

public class GameOverButton : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;

    public void OnRestartClick()
    {
        gameStateManager.SetGameState(GameStateManager.GameState.Play);
    }
}
