using System;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    // private static SaveData _saveData = new SaveData();
    // [Serializable]
    // public struct SaveData
    // {
    //     public HighScoreSaveData HighScoreSaveData;
    // }
    //
    // public static string SaveFileName()
    // {
    //     string savePath = Application.persistentDataPath + "/save" + ".save";
    //     return savePath;
    // }
    //
    // public static void Save()
    // {
    //     HandleSaveData();
    //     
    //     File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    // }
    //
    // private static void HandleSaveData()
    // { 
    //     GameManager.Instance.HighScoreManager.Save(ref _saveData.HighScoreSaveData);
    // }
    //
    // public static void Load()
    // {
    //     string saveData = File.ReadAllText(SaveFileName());
    //     
    //     _saveData = JsonUtility.FromJson<SaveData>(saveData);
    //     HandleSaveData();
    // }
    //
    // private static void HandleLoadData()
    // {
    //     GameManager.Instance.HighScoreManager.Load(_saveData.HighScoreSaveData);
    // }
}
