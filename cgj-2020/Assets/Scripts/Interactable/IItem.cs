using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IItem : IBasic
{
    public int itemCode;

    public Item itemAttach;

    public override IEnumerator InteractWith()
    {
        StartCoroutine(base.InteractWith());
        yield return new WaitWhile(()=>KaraokeController.Instance.IsTalking);
        Debug.Log("Adding to inventory");
        AddToInventory();
        transform.gameObject.SetActive(false);
    }

    private void AddToInventory() {
        InventoryManager.Instance.AddItem(itemCode);
    }
}
