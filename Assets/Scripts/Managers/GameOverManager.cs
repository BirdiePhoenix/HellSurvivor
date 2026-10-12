using System.Collections;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] HighScoreManager highScoreManager;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private float timeToWait;
    [SerializeField] private SaveManager saveManager;
    
    private bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }
    private int showScore;

    public void GameOver()
    {
        IsGameOver = true;
        highScoreManager.UpdateHighScore(highScoreManager.CurrentScore);
        saveManager.SaveGame();
        StartCoroutine(RiseScore());
    }

    private IEnumerator RiseScore()
    {
        while (showScore < highScoreManager.CurrentScore)
        {
            yield return new WaitForSecondsRealtime(timeToWait);
            showScore++;
            scoreText.text = string.Format("{0:00000000}", showScore);
        }
    }
}
