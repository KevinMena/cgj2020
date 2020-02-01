using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IActorNPC : Interactable
{
    public List<Dialogue> dialoguesList = new List<Dialogue>();

    public StateActor currentState;

    public List<StateActor> posibleStates;

    public override void InteractWith() 
    {
        StartDialogue();
    }

    private void StartDialogue() {
        // TO DO
    }

    public void SendGift(int gift) {
        if (currentState.stateCode != 0)
        {
            Debug.Log("You already gifted something to this NPC");
            return;
        }

        for(int i = 0; i < posibleStates.Count; i++) {
            for(int j = 0; j < posibleStates[i].itemList.Count; j++) {
                if(posibleStates[i].itemList[j] == gift) 
                {
                    currentState = posibleStates[i];
                    return;
                }
            }
        }
    }
}
