using System;
using System.Collections.Generic;
using UnityEngine;

namespace Attribute_System
{
    public class AttributeComposite : Attribute
    {
        [SerializeField] private float baseAdditive = 0;
        [SerializeField] private float baseMultiplicative = 1;
        [SerializeField] private List<AttributeEnum> additiveAttributes;
        [SerializeField] private List<AttributeEnum> multiplicativeAttributes;

        private List<Attribute> additive;
        private List<Attribute> multiplicative;

        public void Initialize(CharacterAttributes attributes)
        {
            MyCharacterAttributes = attributes;
            foreach (AttributeEnum attribute in additiveAttributes)
            {
                var currentAttribute = MyCharacterAttributes.GetAttribute(attribute);
                if (currentAttribute == null) continue;
                currentAttribute.OnValueChanged.AddListener(CalculateCurrentValue);
                additive.Add(currentAttribute);
            }
            
            foreach (AttributeEnum attribute in multiplicativeAttributes)
            {
                var currentAttribute = MyCharacterAttributes.GetAttribute(attribute);
                if (currentAttribute == null) continue;
                currentAttribute.OnValueChanged.AddListener(CalculateCurrentValue);
                multiplicative.Add(currentAttribute);
            }
            CalculateCurrentValue();
        }

        public override void CalculateCurrentValue()
        {
            //ADD TOGETHER THE ADDITIVE VALUES
            float additiveTotal = baseAdditive;
            foreach (Attribute attribute in additive) additiveTotal += attribute.currentValue;
            
            //GET MULTIPLICATIVE VALUE
            float multiplicativeTotal = baseAdditive * baseMultiplicative;
            foreach (Attribute attribute in multiplicative) multiplicativeTotal *= attribute.currentValue;
            
            currentValue = multiplicativeTotal;
        }
    }
}
