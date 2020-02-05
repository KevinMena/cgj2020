using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class IItem : IBasic
{
    public int itemCode;

    public Item itemAttach;

    public UnityEvent after;

    public override IEnumerator InteractWith()
    {
        StartCoroutine(base.InteractWith());
        yield return new WaitWhile(()=>KaraokeController.Instance.IsTalking);
        if(!GameManager.Instance.Inventory.IsFull)
        {
            Debug.Log("Adding to inventory");
            AddToInventory();
            transform.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.ExecuteDialogue();
        }

        after.Invoke();
    }

    private void AddToInventory() {
        InventoryManager.Instance.AddItem(itemCode);
    }
}
