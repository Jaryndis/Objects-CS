using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent onScoreUpdated;


    private int score;

    public int GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score++;
        onScoreUpdated?.Invoke();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
