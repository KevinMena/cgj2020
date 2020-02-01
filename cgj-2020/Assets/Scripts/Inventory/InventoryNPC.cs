using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryNPC : Inventory
{
    [SerializeField] public const int NUMBER_SLOTS = 1;

    public override void AddItem(Item itemToAdd)
    {   
        if(inventoryList.Count < NUMBER_SLOTS) 
        {
            inventoryList.Add(itemToAdd);
            return;
        } 
        else
        {
            Debug.Log("Item Cannot be added to NPC. All gifts received");
            return;
        }
    }
}
