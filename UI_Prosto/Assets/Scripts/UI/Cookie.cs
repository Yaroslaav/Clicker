using System;
using UnityEngine;
using Model;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class Cookie : MonoBehaviour
    {
        public static Cookie Instance { get; private set; }
        [SerializeField] private Text score;
        [SerializeField] private GameState  _gameState = GameState.Instance;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _clips;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _gameState = GameState.Instance;
        }

        public void Click()
        {
            _gameState._scoreCounter.ToolClicked(_gameState._scoreCounter.manualTool);
            //score.text = _gameState.Score.ToString();
            PlayMusic();
        }

        private void PlayMusic()
        {
            _audioSource.PlayOneShot(_clips[Random.Range(0, _clips.Length)]);
        }

    }
}
