using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent onScoreUpdated;
    public UnityEvent onHighScoreUpdated;


    private int score;
    private static int highscore;

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highscore;
    }

    public void IncrementScore()
    {
        score++;
        onScoreUpdated?.Invoke();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        onHighScoreUpdated?.Invoke();
        GameManager.GetInstance().OnGameStart += OnGameStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highscore);
    }

    public void OnGameStart()
    {
        score = 0;
        //highscore = 0;
    }
}
