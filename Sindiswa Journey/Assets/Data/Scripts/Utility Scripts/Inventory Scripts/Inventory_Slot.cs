using OWL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Inventory_Slot
{
    [SerializeField] private Inventory_Item itemData;
    [SerializeField] private int stackSize;

    public Inventory_Item ItemDat => itemData;
    public int StackSize => stackSize;

    public Inventory_Slot(Inventory_Item source, int amount)//inventory with stuff in it
    {
        itemData = source;
        stackSize = amount;
    }
    public Inventory_Slot()//inventory with nothing in it
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public bool RoomLeft_In_Stack(int amountToAdd, out int amountRemaing)
    {
        amountRemaing = itemData.maxStackAmount - stackSize;
        return RoomLeft_In_Stack(amountToAdd);
    }
    public bool RoomLeft_In_Stack(int amountToAdd)
    {
        if(stackSize + amountToAdd <= itemData.maxStackAmount)
        {
            return true;
        }
        else return false;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }
    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }
}
