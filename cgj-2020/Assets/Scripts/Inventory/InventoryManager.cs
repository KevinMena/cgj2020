using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<Item> database = new List<Item>();

    public void AddItem(Item itemToAdd)
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

    public Item GetRequestedItem(int requestedItem) 
    {
        return database[requestedItem];
    }
}
