using UnityEngine;

public class GameOverButton : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private TimeManager timeManager;

    public void OnRestartClick()
    {
        timeManager.ResumeTime();
        GameManager.Instance.RestartGame();
    }
}
