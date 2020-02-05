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

    public void Blend(bool isGood)
    {
        anim = GetComponent<Animator>();

        if (isGood)
            anim.SetTrigger("Good");
        else
            anim.SetTrigger("Bad");

    }

    public void Explode() {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Explode");
    }
}
