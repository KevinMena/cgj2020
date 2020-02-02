using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StateActor
{
    public int stateCode;

    public List<int> itemList;

    public Dialogue stateDialogue;

    [SerializeField] UnityEvent stateEvent = null;

    public UnityEvent StateEvent {
        get {
            return stateEvent;
        }
    }
}
