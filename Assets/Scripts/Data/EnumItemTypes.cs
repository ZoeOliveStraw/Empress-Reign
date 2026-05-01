namespace Data
{
    public enum EnumItemTypes
    {
        Basic, //items with no other function but may be "checked" by external scripts
        Consumable, //items that can be "used" from the inventory
        Gold, //items that contribute to user's gold total when added to inventory
        Weapon, //equipped into right hand slot
        Shield, //equipped into left hand slot
        Armor, //equipped into armor slot
        Helm, //equipped into helm slot
        Boots, //equipped into the feet slot
    }
}
