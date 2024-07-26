using OWL;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    public Inventory_Item item;
    public int itemIndex;

    public void RemoveItem()
    {
        Inventory_Manager.Instance.Remove_Item(itemIndex);
        Destroy(gameObject);

        /*int index = Inventory_Manager.Instance.items.IndexOf(item);
        if(index >= 0)
        {
            Inventory_Item obj = Inventory_Manager.Instance.items[index];
            if(obj.itemID == 2)
            {
                print("success?");
            }
        }*/
    }
}
