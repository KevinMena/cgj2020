using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    IActorNPC nPC;

    Animator anim;

    void Awake() 
    {
        nPC = GetComponent<IActorNPC>();
    }

    public void StartPatrol() 
    {
        nPC.isMoving = !nPC.isMoving;
    }

    public void Explode() {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Explode");
    }
}
