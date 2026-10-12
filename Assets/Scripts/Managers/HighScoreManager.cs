using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int currentScore = 0;
    private string scoreString;
    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    public void UpdateScore(int _score)
    {
        CurrentScore += _score;
        scoreString = CurrentScore.ToString();
        scoreText.text = string.Format("{0:00000000}", CurrentScore);
    }
}
