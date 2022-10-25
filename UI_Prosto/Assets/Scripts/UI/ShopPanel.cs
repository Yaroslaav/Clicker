using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField] private List<GameObject> autoToolsPrefabs = new List<GameObject>();
        GameState _gameState = GameState.Instance;

        private void Start()
        {
            _gameState = GameState.Instance;
        }

        public void ActivateNewTool()
        {
            if (autoToolsPrefabs.Count > 0)
            {
                GameObject instantisted = GameObject.Instantiate(autoToolsPrefabs[0],this.gameObject.transform);
                
                autoToolsPrefabs.Remove(autoToolsPrefabs[0]);
            }
        }

        private void Update()
        {
            if(autoToolsPrefabs.Count>0)
                if (_gameState.Score >= autoToolsPrefabs[0].GetComponentInChildren<ShopButton>().ScoreNeed)
                {
                    Debug.Log("wtf");
                    ActivateNewTool();
                }
        }
    }
}
