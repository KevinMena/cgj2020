using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarController : Singleton<HotbarController>
{
    [SerializeField] Slot[] slots = null;

    public Slot selected= null;

    public Slot[] Slots {
        get {
            return slots;
        }
    }

    public int nSlots {
        get {
            return slots.Length;
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < nSlots; i++)
        {
            if (slots[i].isEmpty)
            {
                slots[i].Item = item;
                break;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        if (item == null)
            return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == item)
            {
                slots[i].Item = null;
                break;
            }
        }

        
        
    }

    public Item IsItemSelected()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isEmpty)
                continue;

            if (!slots[i].IsSelected())
                continue;

            return slots[i].Item;
        }

        return null;
    }
}
