using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    GameState _gameState = GameState.Instance;
    [SerializeField] private Text score;

    private void Awake()
    {
        score = this.gameObject.GetComponent<Text>();
    }
    
    void Start()
    {
        _gameState = GameState.Instance;
        _gameState._scoreCounter.OnScoreChanged += UpdateScore;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateScore()
    {
        score.text = _gameState._scoreCounter.Score.ToString();
    }
}
