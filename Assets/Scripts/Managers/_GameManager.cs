using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Interfaces;

public class _GameManager : MonoBehaviour
{
    private static _GameManager _instance;
    public static _GameManager Instance{get{return _instance;}}
    
    private readonly List<ISetup> setupObjects = new List<ISetup>();
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2 playerSpawnPos;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, playerSpawnPos, quaternion.identity);
    }

    public void SetupGame()
    {
        foreach (var obj in setupObjects)
        {
            obj.GetData();
        }
    }

    public void RegisterDataObjects(ISetup setupObject)
    {
        setupObjects.Add(setupObject);
    }
}
