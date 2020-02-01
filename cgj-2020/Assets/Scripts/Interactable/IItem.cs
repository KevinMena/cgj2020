using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IItem : IBasic
{
    public int itemCode;

    public Item itemAttach;

    public override void InteractWith()
    {
        base.InteractWith();

        AddToInventory();
    }

    private void AddToInventory() {
        InventoryManager.Instance.AddItem(itemCode);
    }
}
