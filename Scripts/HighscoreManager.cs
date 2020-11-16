using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    [SerializeField] Text highscoreText;
    [SerializeField] CounterManager counterManager;
    string highScorePlayerPrefab = "highscore";
    string getHighScoreString => "Highscore: " + PlayerPrefs.GetInt(highScorePlayerPrefab).ToString();

    private void Awake()
    {
        counterManager = FindObjectOfType<CounterManager>();
        highscoreText.text = getHighScoreString;
    }
    private void Update()
    {
        GetHighscore(counterManager.GetCounter);
    }
    public void GetHighscore(int score)
    {
        if (score > PlayerPrefs.GetInt(highScorePlayerPrefab))
        {
            PlayerPrefs.SetInt(highScorePlayerPrefab, score);
            highscoreText.text = getHighScoreString;
        }
    }
}
