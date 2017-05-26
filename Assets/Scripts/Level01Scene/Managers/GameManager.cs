using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour // enemy health
{

    // public
    public Text timerText;
    public Text scoreText;

    // public and hidden
    [HideInInspector]
    public static long timerInSeconds;
    [HideInInspector]
    public static int score;
    
    // private
    PlayerHealth playerHealth;
    GameObject player;
    DateTime startTime;

    
    public GameObject[] enemies;
    public float spawnStartTime = 2f;
    public float spawnTime = 1f;
    public Transform[] spawnPoints;

    void Awake()
    {
        player = Resources.Load("Prefabs/Player", typeof(GameObject)) as GameObject; //.FindGameObjectWithTag("Player");
        timerInSeconds = 0;
        score = 0;
        startTime = DateTime.Now;
        playerHealth = player.GetComponent<PlayerHealth>();
        //Instantiate(player);
    }

    void Start()
    {
        InvokeRepeating("UpdateTimerText", 0, 1); // run every seconds
        InvokeRepeating("UpdateScoreText", 0, 0.2f); // run 5x by seconds
        InvokeRepeating("Spawn", spawnStartTime, spawnTime); // wait 2 sec then run every 1sec
    }
    
    void Update()
    {
        if (!playerHealth.IsAlive())
        {
            //Application.CaptureScreenshot(@"Screenshot.png");
            Invoke("GameOver", 5);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        if (!playerHealth.IsAlive())
        {
            return;
        }
        TimeSpan ts = TimeSpan.FromSeconds(timerInSeconds);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        timerInSeconds++;
    }

    void GameOver()
    {
        PlayerData.AddGame(startTime, timerInSeconds, score);
        SceneManager.LoadScene("Result");
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length); // random location
        var enemy = enemies[UnityEngine.Random.Range(0, enemies.Length)]; // random enemy
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

}
