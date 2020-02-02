using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    IActorNPC nPC;

    void Awake() 
    {
        nPC = GetComponent<IActorNPC>();
    }

    public void StartPatrol() 
    {
        nPC.isMoving = !nPC.isMoving;
    }
}
