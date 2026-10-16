using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private EnemySpawner enemySpawner;
    
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI text;
    
    [Header("Local Variables")]
    private bool hasIncreasedSpawning = false; //Is for preventing the increasing to trigger more than once

    int minutes;
    int seconds;

    private float time;
    
    // Update is called once per frame
    void Update()
    {
        if (!gameOverManager.IsGameOver)
        {
            AddTime();
        }
        
        if (seconds % 10 == 0 && seconds > 0 && !hasIncreasedSpawning)
        {
            enemySpawner.IncreaseSpawning();
            hasIncreasedSpawning = true;
        }

        if (seconds % 2 != 0 && hasIncreasedSpawning)
        {
            hasIncreasedSpawning = false;
        }

        if (seconds == 30 && enemySpawner.CurrentEnemyStage == EnemySpawner.EnemyStage.Stage1)
        {
            enemySpawner.SetEnemyStage(EnemySpawner.EnemyStage.Stage2);
        }
    }

    private void AddTime()
    {
        time += Time.deltaTime;

        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);

        if(seconds >= 60) { seconds = 0; }
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
