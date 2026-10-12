using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameOverManager gameOverManager;

    int minutes;
    int seconds;

    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartTimer(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOverManager.IsGameOver)
        {
            AddTime();
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

    private void StartTimer(float minutes)
    {
        time = minutes * 60;
        text.color = Color.cyan;
    }

    public int Minutes { get => minutes; }
    public int Seconds { get => seconds; }
}
