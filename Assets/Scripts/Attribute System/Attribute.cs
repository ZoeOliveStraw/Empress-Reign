using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Attribute_System
{
    
    public class Attribute : MonoBehaviour
    {
        [HideInInspector] public float currentValue;
        [HideInInspector] public UnityEvent OnValueChanged;
        
        [SerializeField] public AttributeEnum AttributeEnumType;
        [SerializeField] private float baseValue;
        private List<AttributeModifier> modifiers;

        protected CharacterAttributes MyCharacterAttributes;

        public void Initialize(CharacterAttributes characterAttributes)
        {
            modifiers = new List<AttributeModifier>();
            MyCharacterAttributes = characterAttributes;
            CalculateCurrentValue();
        }

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

        public virtual void CalculateCurrentValue()
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
            Debug.LogWarning($"Calculated {AttributeEnumType} value: {value}");
            currentValue = value;
            OnValueChanged?.Invoke();
        }
    }
}
