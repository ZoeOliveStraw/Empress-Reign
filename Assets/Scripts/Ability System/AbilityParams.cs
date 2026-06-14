using UnityEngine;

namespace Ability_System
{
    public struct AbilityParams
    {
        public GameObject AffectedGameObject;
        public Vector3 Direction;

        public AbilityParams(GameObject affectedGameObject = null, Vector3 direction = default)
        {
            AffectedGameObject = affectedGameObject;
            Direction = direction;
        }
    }
}