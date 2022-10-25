using System;
using Model;
using UnityEngine;

namespace UI
{
    public enum ImproveType
    {
        NewAutoTool,
        UpdateTool
    }
    public class ShopButton : MonoBehaviour
    {
        GameState _gameState = GameState.Instance;
        public Cookie cookie = Cookie.Instance;
        [SerializeField] private ImproveType _improveType;
        [SerializeField] private Tool Findedtool;
        [SerializeField] private float UseRange;
        public float ScoreNeed;
        private void Start()
        {
            _gameState = GameState.Instance;
        }


        public void UpdateTool(float modifier)
        {
            Findedtool.IncreaseModifier(modifier);
        }

        public void DetermineUseRange(float useRange)
        {
            UseRange = useRange;
        }
        public void NewTool(string toolName)
        {
            _gameState._scoreCounter.AddTool(new Tool(1, 3, ToolType.Automatic, toolName, UseRange));
        }

        public void Destroy()
        {
            _gameState._scoreCounter.ReduceScore(ScoreNeed);
            GameObject.Destroy(this.gameObject);
        }

        public void FindTool(string toolname)
        {
            foreach (var tool in _gameState._scoreCounter.automaticTools)
            {
                if (tool.Name == toolname)
                {
                    Findedtool = tool;
                    return;
                }
            }
            Findedtool = _gameState._scoreCounter.manualTool;

        }
    }
}
