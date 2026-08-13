using Data;
using Managers;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryPlayer : InventoryComponent
    {
        [SerializeField] private SO_InventoryWeapon debugWeapon;
        [SerializeField] private Transform weaponParent;

        private bool isWeaponEquipped;
        private PlayerWeapon currentWeaponPrefab;
        
        public override bool InitializeInventory()
        {
            inventoryData = PlayerManager.Instance.PlayerInventoryData;
            if (inventoryData == null)
            {
                Debug.Log("Player manager has no InventoryData, returning");
                return false;
            }
            //TODO: REMOVE DEBUG CODE
            return true;
        }

        public void ToggleWeaponEquipped()
        {
            if(isWeaponEquipped) UnequipWeapon();
            else EquipWeapon(debugWeapon);
        }

        public void EquipWeapon(SO_InventoryWeapon weapon)
        {
            Debug.Log("Equipping weapon");
            GameObject weaponGO = Instantiate(debugWeapon.WeaponPrefab, weaponParent.position, weaponParent.transform.rotation);
            weaponGO.transform.SetParent(weaponParent);
            currentWeaponPrefab = weaponGO.GetComponent<PlayerWeapon>();
            currentWeaponPrefab.Initialize(GetComponent<Actor>());
            isWeaponEquipped = true;
        }

        public void UnequipWeapon()
        {
            isWeaponEquipped = false;
            currentWeaponPrefab.UnequipWeapon();
            currentWeaponPrefab.OnUnequipFinishAction += UnequipWeaponFinishedCallback;
        }

        public void UnequipWeaponFinishedCallback()
        {
            currentWeaponPrefab.OnUnequipFinishAction -= UnequipWeaponFinishedCallback;
            Destroy(currentWeaponPrefab);
        }
    }
}