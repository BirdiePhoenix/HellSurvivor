using System;
using Interfaces;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreTextPause;
    [SerializeField] private TextMeshProUGUI higscoreTextGO;
    [SerializeField] private SaveManager saveManager;
    
    private int currentHighScore;
    
    private void Awake()
    {
        saveManager.Register(this);
    }


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
    
    public void SaveData(SaveData saveData)
    {
        saveData.HighScore = CurrentHighScore;
    }

    public void LoadData(SaveData saveData)
    {
        CurrentHighScore = saveData.HighScore;
    }
}
