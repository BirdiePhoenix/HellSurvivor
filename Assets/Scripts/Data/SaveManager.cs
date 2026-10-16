using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Interfaces;

public class SaveManager : MonoBehaviour
{ //This script controls the saving and loading of data
    private readonly List<IDataPersistence> persistencesObjects = new List<IDataPersistence>();
    private string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    private void Start()
    {
        StartCoroutine(LoadAfterInit());
    }

    private IEnumerator LoadAfterInit()
    {
        yield return null;
        LoadGame();
    }
    
    public void Register(IDataPersistence persistenceObjects) //Stores all scripts with the interface IDataPersistence 
    {                                                         
        persistencesObjects.Add(persistenceObjects);
    }
    
    public void SaveGame()
    {
        SaveData saveData = new SaveData();

        foreach (var obj in persistencesObjects)
        {
            obj.SaveData(saveData); //Calls the SaveData method in all IDataPersistance classes
        }
        
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(SavePath, json);
        Debug.Log(json);
    }

    public void LoadGame()
    {
        if (!File.Exists(SavePath))
        {
            return;
        }
        string json = File.ReadAllText(SavePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        foreach (var obj in persistencesObjects)
        {
            obj.LoadData(saveData);
        }
    }
}
