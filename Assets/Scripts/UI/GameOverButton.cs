using UnityEngine;

public class GameOverButton : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private TimeManager timeManager;

    public void OnRestartClick()
    {
        timeManager.ResumeTime();
        _GameManager.Instance.RestartGame();
    }
}
