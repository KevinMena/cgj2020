using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected List<Item> inventoryList = new List<Item>();

    [SerializeField] Item module1;

    [SerializeField] Item module2;

    [SerializeField] const int NUMBER_SLOTS = 6;

    void Start() {
        ResetInventory();
    }

    public void ResetInventory() {
        inventoryList.Clear();
    }

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
