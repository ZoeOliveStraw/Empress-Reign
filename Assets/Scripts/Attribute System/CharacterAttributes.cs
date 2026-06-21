using System.Collections.Generic;
using UnityEngine;

namespace Attribute_System
{
    public class CharacterAttributes : MonoBehaviour
    {
        [SerializeField] private Transform AttributeContainer;
    
        private Dictionary<Attributes, Attribute> _attributes = new Dictionary<Attributes, Attribute>();

        private void Start()
        {
            GetAttributes();
        }

        private void GetAttributes()
        {
            var attributes = AttributeContainer.GetComponents<Attribute>();
            foreach (var attribute in attributes)
            {
                Debug.LogWarning($"Adding attribute {attribute.attributeType}");
                _attributes.Add(attribute.attributeType, attribute);
                attribute.Initialize();
            }
        }

        public float GetAttributeValue(Attributes attribute)
        {
            return _attributes[attribute].currentValue;
        }

        public Attribute GetAttribute(Attributes attribute)
        {
            if (!_attributes.TryGetValue(attribute, out var result))
            {
                Debug.LogError(
                    $"Attribute {attribute} not found. " +
                    $"Dictionary contains: {string.Join(", ", _attributes.Keys)}"
                );
                return null;
            }

            return result;
        }
    }
}
