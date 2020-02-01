﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item module;

    [SerializeField] const int NUMBER_SLOTS = 6; 

    [SerializeField] List<Item> inventoryList = new List<Item>();

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
        
    }
}
