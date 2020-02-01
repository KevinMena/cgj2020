using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] protected List<Item> inventoryList = new List<Item>();

    public abstract void AddItem(Item itemToAdd);

    public void RemoveItem(Item itemToRemove) 
    {
        inventoryList.Remove(itemToRemove);
    }

    public Item GetRequestedItem(string requestedItem) 
    {
        Item itemFound = inventoryList.Find(item => item.itemName.Equals(requestedItem));
        return itemFound;
    }
}
