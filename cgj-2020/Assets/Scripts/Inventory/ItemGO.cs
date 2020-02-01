using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGO : MonoBehaviour
{
    public Item itemAttach;

    public int itemCode;

    public IEnumerator InteractWith() {
        //Show description

        AddToInventory();

        yield return null;
    }

    private void AddToInventory() {
        InventoryManager.Instance.AddItem(itemCode);
    }
}
