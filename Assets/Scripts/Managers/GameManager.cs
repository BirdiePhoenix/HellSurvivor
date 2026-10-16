using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Interfaces;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2 playerSpawnPos;
    
    [Header("Singleton Variables")]
    private static GameManager instance;
    public static GameManager Instance{get{return instance;}}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, playerSpawnPos, quaternion.identity);
    }

    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
