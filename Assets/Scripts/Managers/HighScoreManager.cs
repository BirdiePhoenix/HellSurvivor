using System;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreTextPause;
    [SerializeField] private TextMeshProUGUI higscoreTextGO;
    
    private int currentHighScore;

    private void Start()
    {
        UpdateHighScore(CurrentHighScore);
    }

    public int CurrentHighScore
    {
        get { return currentHighScore; }
        set { currentHighScore = value; }
    }
    private int currentScore = 0;
    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }
    
    private string scoreString;

    public void UpdateScore(int _score)
    {
        CurrentScore += _score;
        scoreString = CurrentScore.ToString();
        scoreText.text = string.Format("{0:00000000}", CurrentScore);
    }

    public void UpdateHighScore(int _highScore)
    {
        if(CurrentHighScore < CurrentScore)
        {
            CurrentHighScore = CurrentScore;
        }
        scoreString = CurrentHighScore.ToString();
        highScoreTextPause.text = string.Format("{0:00000000}", CurrentHighScore);
        higscoreTextGO.text = string.Format("{0:00000000}", CurrentHighScore);
    }

    // #region Save and Load
    //
    // public void Save(ref HighScoreSaveData highScoreSave)
    // {
    //     highScoreSave.HighScoreAmount = CurrentHighScore;
    // }
    //
    // public void Load(HighScoreSaveData highScoreSave)
    // {
    //     CurrentHighScore = highScoreSave.HighScoreAmount;
    //     
    //     UpdateHighScore(highScoreSave.HighScoreAmount);
    // }
    //
    // #endregion
}
//
// [Serializable]
// public struct HighScoreSaveData
// {
//     public int HighScoreAmount;
// }
