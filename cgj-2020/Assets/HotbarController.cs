using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarController : Singleton<HotbarController>
{
    [SerializeField] Slot[] slots = null;



    public Slot[] Slots {
        get {
            return slots;
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
