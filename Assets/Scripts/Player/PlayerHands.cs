using UnityEngine;

namespace Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private Transform handPrefabParent;
        [SerializeField] public PlayerHandObject_Abstract leftHandObject;
        [SerializeField] public PlayerHandObject_Weapon rightHandObject;
        
        private InputSystem_Actions input;

        public void EquipRightHandObject(SO_InventoryWeapon so)
        {
            GameObject prefab = so.weaponPrefab;
            prefab = Instantiate(prefab, handPrefabParent);
            rightHandObject = prefab.GetComponent<PlayerHandObject_Weapon>();
        }

        public void UseRightHandObject()
        {
            rightHandObject.PlayUseAnimation();
        }
    }
}
