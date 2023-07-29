using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text txtHealth;
    [SerializeField] TMP_Text txtScore;
    [SerializeField] private TMP_Text txtHighScore;
    [SerializeField] private TMP_Text txtMenuHighScore;
    [SerializeField] private Player player;
    
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject lblGameOverText;

    private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = GameManager.GetInstance().scoreManager;

        GameManager.GetInstance().OnGameStart += GameStarted;
        GameManager.GetInstance().OnGameEnd += GameEnded;
        
        // player.Health.OnHealthUpdate += UpdateHealth;
    }

    private void GameEnded()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }



    public void UpdateHealth(float currentHealth)
    {
        txtHealth.SetText(currentHealth.ToString());
    }


    public void GameStarted()
    {
        txtScore.SetText("0");

        player = GameManager.GetInstance().GetPlayer();
        player.health.OnHealthUpdate += UpdateHealth;

        menuCanvas.SetActive(false);
    }
    
    public void GameOver()
    {
        player.health.OnHealthUpdate -= UpdateHealth;
        lblGameOverText.SetActive(true);
        menuCanvas.SetActive(true);
    }

    public void UpdateScore()
    {
        txtScore.SetText(_scoreManager.GetScore().ToString());
        
        // txtScore.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
    }
    
    public void UpdateHighScore()
    {
        //txtScore.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
        txtHighScore.SetText(_scoreManager.GetHighScore().ToString());
        txtMenuHighScore.SetText($"High score {_scoreManager.GetHighScore()}");
    }
}
