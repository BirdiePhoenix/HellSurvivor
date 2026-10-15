using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    //State machine
    //List of available enemies
    //Increase amount of enemies to spawn
    [SerializeField] private GameObject flyingEye;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    private List<GameObject> enemieList = new List<GameObject>();

    [SerializeField] private EnemyPool enemyPool;
    private float interval;
    
    public enum EnemyStage
    {
        Stage1,
        Stage2,
        Stage3
    }
    public EnemyStage CurrentEnemyStage{get; private set;}

    private void Start()
    {
        InitializeList();
    }

    public void InitializeList()
    {
        SetEnemyStage(EnemyStage.Stage1);
    }

    public void GameRestart()
    {
        enemieList.Clear();
    }

    public void IncreaseSpawning(int playerLevel)
    {
        
    }

    public void SetEnemyStage(EnemyStage enemyStage)
    {
        if(enemyStage == CurrentEnemyStage) return;

        switch (enemyStage)
        {
            case EnemyStage.Stage1:
                enemieList.Add(flyingEye);
                break;
            case EnemyStage.Stage2:
                enemieList.Add(enemy2);
                break;
            case EnemyStage.Stage3:
                enemieList.Add(enemy3);
                break;
            default:
                Debug.LogError($"{enemyStage} is an invalid stage!");
                break;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        GetEnemies(CurrentEnemyStage);
        yield return new WaitForSeconds(interval);
    }
    
    private void GetEnemies(EnemyStage enemyStage)
    {
        switch (enemyStage)
        {
            case EnemyStage.Stage1:
                Stage1();
                break;
            case EnemyStage.Stage2:
                Stage2();
                break;
            case EnemyStage.Stage3:
                Stage3();
                break;
            default:
                Debug.LogError($"{enemyStage} is an invalid stage!");
                break;
        }
    }
    
    private void Stage1()
    {
        
    }

    private void Stage2()
    {
        
    }

    private void Stage3()
    {
        
    }
}
