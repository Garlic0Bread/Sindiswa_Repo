using OWL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PickUp : MonoBehaviour, IInteractable
{
    public Inventory_Item itemToPickUp;

    public void Interact()
    {
        Inventory_Manager.Instance.Add_Item(itemToPickUp);
        Destroy(gameObject);
    } 
}
