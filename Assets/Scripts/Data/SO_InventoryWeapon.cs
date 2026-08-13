using Data;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_InventoryWeapon", menuName = "Scriptable Objects/Inventory Items/Weapon")]
public class SO_InventoryWeapon : SO_InventoryEquipment
{
    [Header("WEAPON FIELDS")] 
    [SerializeField] public float BaseDamage;
    [SerializeField] public float BaseAttackSpeed;
    [SerializeField] public DamageType DmaageType;
    [SerializeField] public GameObject WeaponPrefab;
}
