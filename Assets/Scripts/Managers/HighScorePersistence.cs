using System;
using Interfaces;
using UnityEngine;

public class HighScorePersistence : MonoBehaviour, IDataPersistence
{
    [SerializeField] HighScoreManager highScoreManager;
    [SerializeField] SaveManager saveManager;

    private void Awake()
    {
        saveManager.Register(this);
    }

    public void SaveData(SaveData saveData)
    {
        saveData.HighScore = highScoreManager.CurrentHighScore;
    }

    public void LoadData(SaveData saveData)
    {
        highScoreManager.CurrentHighScore = saveData.HighScore;
    }
}
