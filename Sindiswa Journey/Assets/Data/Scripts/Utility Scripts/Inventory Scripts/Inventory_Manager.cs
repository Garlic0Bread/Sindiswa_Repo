using OWL;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour
{
    public static Inventory_Manager Instance;

    public Transform inventoryContent;
    public GameObject inventoryItem;
    public List<Inventory_Item> items = new List<Inventory_Item>();

    public void Awake()
    {
        Instance = this;
    }
    
    public void Add_Item(Inventory_Item item)
    {
        items.Add(item);
    }
    public void Remove_Item(int item)
    {
        items.RemoveAt(item);
    }
   
    public void List_Items_Into_Bag()
    {
        //clean content
        foreach(Transform item in inventoryContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, inventoryContent);
            var itemName = obj.transform.Find("itemName").GetComponent<Text>();
            itemName.text = item.itemName;
        }
    }
}
