using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarController : Singleton<HotbarController>
{
    [SerializeField] Slot[] slots = null;

    public Slots[] Slots {
        get {
            return slots;
        }
    }
}
