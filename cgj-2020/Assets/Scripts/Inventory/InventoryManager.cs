using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public GameObject player;

    [SerializeField] List<Item> database = new List<Item>();

    public void AddItem(int itemToAdd)
    {   
        player.GetComponent<Inventory>().AddItem(GetRequestedItem(itemToAdd));
    }

    public void RemoveItem(int itemToRemove)
    {
        player.GetComponent<Inventory>().RemoveItem(GetRequestedItem(itemToRemove));
    }

    public Item GetRequestedItem(int requestedItem) 
    {
        return database[requestedItem];
    }
}
