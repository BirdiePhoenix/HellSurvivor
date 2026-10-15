using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class _EnemySpawner : MonoBehaviour
{
    //State machine
    //List of available enemies
    //Increase amount of enemies to spawn
    [Header("Enemies")]
    // [SerializeField] private GameObject flyingEye;
    // [SerializeField] private GameObject enemy2;
    // [SerializeField] private GameObject enemy3;
    // private List<GameObject> enemieList = new List<GameObject>();
    // private GameObject enemyToSpawn;
    // public GameObject EnemyToSpawn
    // {
    //     get => enemyToSpawn;
    //     set => enemyToSpawn = value;
    // }

    [Header("Interval")]
    [SerializeField] private float intervalIncrease;
    [SerializeField] private float interval;
    public float IntervalIncrease
    {
        get => intervalIncrease;
        set => intervalIncrease = value;
    }
    
    [Header("References")]
    [SerializeField] private FlyingEyePool flyingEyePool;
    [SerializeField] private Enemy2Pool enemy2Pool;
    [SerializeField] private Enemy3Pool enemy3Pool;
    private GameObject player;
    
    [Header("EnemyStage")]
    public EnemyStage CurrentEnemyStage{get; private set;}

    public static Action<EnemyStage> OnEnemyStageChange;
    public enum EnemyStage
    {
        Stage1,
        Stage2,
        Stage3
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
        if (interval > 0.5)
        {
            interval -= intervalIncrease;
        }
    }

    public void SetEnemyStage(EnemyStage enemyStage)
    {
        if(enemyStage == CurrentEnemyStage) return;

        // switch (enemyStage)
        // {
        //     case EnemyStage.Stage1:
        //         enemieList.Add(flyingEye);
        //         break;
        //     case EnemyStage.Stage2:
        //         enemieList.Add(enemy2);
        //         break;
        //     case EnemyStage.Stage3:
        //         enemieList.Add(enemy3);
        //         break;
        //     default:
        //         Debug.LogError($"{enemyStage} is an invalid stage!");
        //         break;
        // }
        
        OnEnemyStageChange?.Invoke(enemyStage);
        CurrentEnemyStage = enemyStage;
    }

    private IEnumerator SpawnEnemies()
    {
        GetEnemies(CurrentEnemyStage);
        GameObject newEnemy = GetEnemies(CurrentEnemyStage);///
        Vector2 spawnPos = CalculateSpawnPoint();
        newEnemy.transform.position = spawnPos;
        yield return new WaitForSeconds(interval);
        StartCoroutine(SpawnEnemies());
    }
    
    private GameObject GetEnemies(EnemyStage enemyStage)
    {
        switch (enemyStage)
        {
            case EnemyStage.Stage1:
                return Stage1();
            case EnemyStage.Stage2:
                return Stage2();
            case EnemyStage.Stage3:
                return Stage3();
            default:
                Debug.LogError($"{enemyStage} is an invalid stage!");
                return null;
        }
    }
    
    private GameObject Stage1()
    {
        return GetFlyingEye();
    }

    private GameObject Stage2()
    {
        float randomNum = Random.Range(0f, 1f);
        if (randomNum < 0.7f)
        {
            return GetFlyingEye();
        }
        else
        {
            return GetEnemy2();
        }
    }

    private GameObject Stage3()
    {
        float randomNum = Random.Range(0f, 1f);
        if (randomNum < 0.5f)
        {
            return GetFlyingEye();
        }
        else if (randomNum < 0.8f)
        {
            return GetEnemy2();
        }
        else
        {
            return GetEnemy3();
        }
    }

    private Vector2 CalculateSpawnPoint()
    {
        return new Vector2(Random.Range(player.transform.position.x + 5 -5f, player.transform.position.x + 5 + 5), 
            Random.Range(player.transform.position.y + 5 -6f, player.transform.position.y + 5 + 6));
    }

    private GameObject GetFlyingEye()
    {
        return flyingEyePool.GetObject();
    }

    private GameObject GetEnemy2()
    {
        return enemy2Pool.GetObject();
    }

    private GameObject GetEnemy3()
    {
        return enemy3Pool.GetObject();
    }
}
