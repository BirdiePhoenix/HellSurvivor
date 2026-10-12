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
    private void Awake()
    {
        SpawnPlayer();
        
    }

    private void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSetup>();
    }
    

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, playerSpawnPos, quaternion.identity);
    }

    private void SpawnEnemies()
    {
        
    }

    public void SceneTransition()
    {
        
    }
    
}
