using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : Inventory
{
    [SerializeField] Item module;

    [SerializeField] const int NUMBER_SLOTS = 6;

    void Start() {
        ResetInventory();
    }

    public void ResetInventory() {
        inventoryList.Clear();
    }

    public override void AddItem(Item itemToAdd)
    {   
        if(inventoryList.Count < NUMBER_SLOTS) 
        {
            inventoryList.Add(itemToAdd);
            return;
        } 
        else
        {
            Debug.Log("Inventory Full");
            return;
        }
    }
}
