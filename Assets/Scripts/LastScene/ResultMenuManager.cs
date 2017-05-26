using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ResultMenuManager : MonoBehaviour
{

    public Text nameText;
    public Text scoreText;
    public Text timerText;

    void Start()
    {
        Game lastGame = PlayerData.GetLastGame();
        if (lastGame == null)
            return;
        nameText.text = "Name: " + PlayerData.Name;
        scoreText.text = "Score: " + lastGame.score;
        TimeSpan ts = TimeSpan.FromSeconds(lastGame.numberSeconds);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Exit()
    {
        Application.Quit();
    }
}