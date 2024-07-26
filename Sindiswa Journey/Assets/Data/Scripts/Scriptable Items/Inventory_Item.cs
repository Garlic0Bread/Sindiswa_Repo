using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    //a script that functions as a template for iinventory item stats/details
    [CreateAssetMenu(menuName = "Items/Inventory Item")]

    public class Inventory_Item : ScriptableObject
    {
        [Header("Item Information")]
        [TextArea(4,4)]
        public string itemDescription;
        public int maxStackAmount;
        public Sprite itemIcon;
        public string itemName;
        public int itemID;

        [Header("Item Settings")]
        public ItemCategory Category;
    }

    public enum ItemCategory
    {
        Historical, Weapon, Armour, Edible
    }
}

