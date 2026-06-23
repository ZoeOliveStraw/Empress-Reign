using System.Collections.Generic;
using UnityEngine;

namespace Attribute_System
{
    public class CharacterAttributes : MonoBehaviour
    {
        [SerializeField] private Transform AttributeContainer;
    
        private Dictionary<AttributeEnum, Attribute> _attributes = new Dictionary<AttributeEnum, Attribute>();
        private Dictionary<AttributeEnum, Attribute> _compositeAttributes = new Dictionary<AttributeEnum, Attribute>();

        private void Start()
        {
            GetAttributes();
            GetCompositeAttributes();
        }

        private void GetAttributes()
        {
            var attributes = AttributeContainer.GetComponents<Attribute>();
            foreach (var attribute in attributes)
            {
                if (attribute is AttributeComposite) continue;
                Debug.LogWarning($"Adding attribute {attribute.AttributeEnumType}");
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
                Debug.LogWarning($"Adding attribute {attribute.AttributeEnumType}");
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
            if (!_attributes.TryGetValue(attributeEnum, out var result))
            {
                Debug.LogError(
                    $"Attribute {attributeEnum} not found. " +
                    $"Dictionary contains: {string.Join(", ", _attributes.Keys)}"
                );
                return null;
            }

            return result;
        }
    }
}
