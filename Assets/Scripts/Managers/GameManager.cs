using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2 playerSpawnPos;
    [SerializeField] private float xpValue;
    private PlayerSetup playerSetup;
    private PlayerInput playerInput;
    
    // private static GameManager _instance;
    //
    // public static GameManager Instance
    // {
    //     get
    //     {
    //         if (!Application.isPlaying)
    //         {
    //             return null;
    //         }
    //
    //         if (_instance == null)
    //         {
    //             Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
    //         }
    //         return _instance;
    //     }
    // }
    
    public HighScoreManager HighScoreManager { get; private set; }
    private void Awake()
    {
        LoadHighscore();
        SpawnPlayer();
    }

    private void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
    }
    

    private void SpawnPlayer()
    {
        //Instantiate(playerPrefab, playerSpawnPos, quaternion.identity);
    }

    private void LoadHighscore()
    {
    }

    public void SaveHighScore()
    {
    }

    private void SpawnEnemies()
    {
        
    }

    public void SceneTransition()
    {
        
    }
    
}
