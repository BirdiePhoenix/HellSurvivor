using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Header("Interval")]
    [SerializeField] private float intervalIncrease;
    [SerializeField] private float spawnInterval;
    public float IntervalIncrease
    {
        get => intervalIncrease;
        set => intervalIncrease = value;
    }
    
    [Header("SpawnPoints")]
    [SerializeField] private GameObject[] spawnPoints;
    private float randomNum;

    public GameObject[] SpawnPoints
    {
        get => spawnPoints;
        set => spawnPoints = value;
    }
    
    [Header("References")]
    [SerializeField] private FlyingEyePool flyingEyePool;
    [SerializeField] private SlimePool slimePool;
    private GameObject player;
    
    [Header("EnemyStage")]
    public EnemyStage CurrentEnemyStage{get; private set;}

    public static Action<EnemyStage> OnEnemyStageChange;
    public enum EnemyStage //Is for making the spawning of different enemy type into stages
    {
        Stage1,
        Stage2
    }
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyStage(EnemyStage.Stage1);
        StartCoroutine(SpawnEnemies());
    }
    
    public void GameRestart()
    {
        CurrentEnemyStage = EnemyStage.Stage1;
    }

    public void IncreaseSpawning()
    {
        if (spawnInterval > 0.5)
        {
            spawnInterval -= IntervalIncrease;
        }
    }

    public void SetEnemyStage(EnemyStage enemyStage)
    {
        if(enemyStage == CurrentEnemyStage) return;
        
        OnEnemyStageChange?.Invoke(enemyStage);
        CurrentEnemyStage = enemyStage;
    }

    private IEnumerator SpawnEnemies()
    {
        GameObject newEnemy = GetEnemies(CurrentEnemyStage);
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnEnemies());
    }
    
    private GameObject GetEnemies(EnemyStage enemyStage)
    {
        switch (enemyStage)
        {
            case EnemyStage.Stage1:
                return GetFlyingEye();
            case EnemyStage.Stage2:
                randomNum = Random.Range(0f, 1f);
                if (randomNum < 0.5f)
                {
                    return GetFlyingEye();
                }
                else
                {
                    return GetSlime();
                }
            default:
                Debug.LogError($"{enemyStage} is an invalid stage!");
                return null;
        }
    }
    

    private GameObject GetFlyingEye()
    {
        return flyingEyePool.GetObject();
    }

    private GameObject GetSlime()
    {
        return slimePool.GetObject();
    }

    public GameObject GenerateSpawnPoint()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }
}
