namespace Model
{
    public enum ToolType
    {
        Manual,
        Automatic
    }
    
    public class Tool
    {
        public float Modifier { get; private set; }
        public float BaseValue { get; private set; }
        public float NextUse { get; set; }
        public string Name { get; private set; }
        public float UseRange = 0;


        private ToolType toolType;

        public Tool(float modifier, float baseValue, ToolType newToolType, string name)
        {
            Modifier = modifier;
            BaseValue = baseValue;
            toolType = newToolType;
            Name = name;
        }
        public Tool(float modifier, float baseValue, ToolType newToolType, string name, float useRange )
        {
            Modifier = modifier;
            BaseValue = baseValue;
            toolType = newToolType;
            Name = name;
            UseRange = useRange;
        }

        public void IncreaseBaseValue(float newValue)
        {
            BaseValue += newValue;
        }

        public void IncreaseModifier(float newMultiplier)
        {
            Modifier += newMultiplier;
        }

        public float GetValue() => BaseValue * Modifier;

        public bool IsAutomatic => toolType == ToolType.Automatic;

        public bool IsManual => toolType == ToolType.Manual;
    }
}