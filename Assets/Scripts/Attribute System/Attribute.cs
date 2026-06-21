using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Attribute_System
{
    public enum Attributes
    {
        Vitality,
        Strength,
        Speed
    }
    
    public class Attribute : MonoBehaviour
    {
        [HideInInspector] public float currentValue;
        [HideInInspector] public UnityEvent OnValueChanged;
        
        [SerializeField] public Attributes attributeType;
        [SerializeField] private float baseValue;
        private List<AttributeModifier> modifiers;

        public AttributeModifier AddModifier(float value, ModifierType type)
        {
            AttributeModifier modifier = new AttributeModifier(value, type);
            modifiers.Add(modifier);
            CalculateCurrentValue();
            OnValueChanged?.Invoke();
            return modifier;
        }

        public void RemoveModifier(AttributeModifier modifier)
        {
            if (modifiers.Contains(modifier))
            {
                modifiers.Remove(modifier);
            }
            CalculateCurrentValue();
            OnValueChanged?.Invoke();
        }

        private void CalculateCurrentValue()
        {
            float value = baseValue;
            foreach (AttributeModifier modifier in modifiers.Where(m => m.Type == ModifierType.Additive))
            {
                value += modifier.Value;
            }

            foreach (var modifier in modifiers.Where(m => m.Type == ModifierType.Multiplicative))
            {
                 value *= modifier.Value;
            }
            currentValue = value;
        }
    }
}
