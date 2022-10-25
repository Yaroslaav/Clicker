using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Model
{
    public class ScoreCounter : MonoBehaviour
    {
        public float Score 
        {         
            get => score;
            private set
            {
                score = value;
                OnScoreChanged?.Invoke();
            }
        }
        public Action OnScoreChanged;
        public List<Tool> automaticTools;
        public Tool manualTool;
        public ScoreCounter()
        {
            automaticTools = new List<Tool>();
            manualTool = new Tool(1, 1, ToolType.Manual, "mouseClick", 0);

            Score = 0;
        }

        private float score;

        private void Awake()
        {
            Score = 0;
        }

        public void AddTool(Tool tool)
        {
            if(tool.IsAutomatic)
                automaticTools.Add(tool);
        }

        public void Update()
        {
            foreach (var tool in automaticTools)
            {
                if (Time.time - tool.NextUse >= tool.UseRange)
                {
                    Score += tool.GetValue();
                    
                }
                
            }

            for (int i = 0; i < automaticTools.Count; i++)
            {
                if (Time.time - automaticTools[i].NextUse >= automaticTools[i].UseRange)
                {
                    Score += automaticTools[i].GetValue();
                    automaticTools[i].NextUse = Time.time;
                }
            }

        }

        public void AddScore(int value)
        {
            Score += value;
        }
        public void ReduceScore(float value)
        {
            Score -= value;
        }
        public void ToolClicked(Tool tool)
        {
            Score += tool.GetValue();
        }
        private IEnumerator UseAutomaticToolsWithUseRange(Tool tool)
        {
            
            yield return new WaitForSeconds(tool.UseRange);
            Score += tool.GetValue();
        } 
    }
}