using System;

namespace Attribute_System
{
    public enum ModifierType
    {
        Additive,
        Multiplicative,
    }
    
    [Serializable]
    public class AttributeModifier
    {
        public float Value;
        public ModifierType Type;

        public AttributeModifier(float value, ModifierType type)
        {
            Value = value;
            Type = type;
        }
    }
}