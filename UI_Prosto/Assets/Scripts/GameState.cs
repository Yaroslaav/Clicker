using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public float Score
    {
        get => _scoreCounter.Score;
        private set
        {
            
        }
    }
    
    public float TotalClicks { get; set; }
    public ScoreCounter _scoreCounter;
    public List<Tool> tools = new List<Tool>();
    private void Awake()
    {
        //_scoreCounter = new ScoreCounter();
        Score = _scoreCounter.Score;
        Instance = this;
    }

    private void Update()
    {
        if(Score!= _scoreCounter.Score)
            Score = _scoreCounter.Score;
    }

}
