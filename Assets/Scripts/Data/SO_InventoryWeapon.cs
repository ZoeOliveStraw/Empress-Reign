using Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SO_InventoryWeapon", menuName = "Scriptable Objects/Inventory Items/Weapon")]
public class SO_InventoryWeapon : SO_InventoryEquipment
{
    [Header("WEAPON FIELDS")] 
    [SerializeField] public float baseDamage;
    [SerializeField] public float baseAttackSpeed;
    [SerializeField] public DamageType damageType;
    [SerializeField] public GameObject weaponPrefab;
}
