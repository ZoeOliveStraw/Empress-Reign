using System.Collections.Generic;
using UnityEngine;

namespace Attribute_System
{
    public class CharacterAttributes : MonoBehaviour
    {
        [SerializeField] private Transform AttributeContainer;
    
        private Dictionary<AttributeEnum, Attribute> _attributes = new Dictionary<AttributeEnum, Attribute>();
        private Dictionary<AttributeEnum, Attribute> _compositeAttributes = new Dictionary<AttributeEnum, Attribute>();

        public void Initialize()
        {
            _attributes.Clear();
            _compositeAttributes.Clear();
            GetAttributes();
            GetCompositeAttributes();
        }

        private void GetAttributes()
        {
            var attributes = AttributeContainer.GetComponents<Attribute>();
            foreach (var attribute in attributes)
            {
                if (attribute is AttributeComposite) continue;
                _attributes.Add(attribute.AttributeEnumType, attribute);
                attribute.Initialize(this);
            }
        }

        //Attribute composites are derived after 
        private void GetCompositeAttributes()
        {
            var compositeAttributes = AttributeContainer.GetComponents<AttributeComposite>();
            foreach (AttributeComposite attribute in compositeAttributes)
            {
                _compositeAttributes.Add(attribute.AttributeEnumType, attribute);
                attribute.Initialize(this);
            }
        }

        public float GetAttributeValue(AttributeEnum attributeEnum)
        {
            return _attributes[attributeEnum].currentValue;
        }

        public Attribute GetAttribute(AttributeEnum attributeEnum)
        {
            Attribute result;

            foreach (var attribute in _attributes)
                if (attribute.Key == attributeEnum) return attribute.Value;
            foreach (var composite in _compositeAttributes)
                if (composite.Key == attributeEnum) return composite.Value;

            return null;
        }
    }
}
