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

    
}
