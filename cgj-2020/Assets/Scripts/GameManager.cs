using UnityEngine;
using System.Collections;
using System;

public class GameManager : Singleton <GameManager>
{
    public IActorNPC[] actors;
    [SerializeField] Inventory inventory = null;
    [SerializeField] int[] states = null;

    [SerializeField] Dialogue fullDialogue;

    private int language = 0;

    public int Language {
        get {
            return language;
        }
    }

    public Inventory Inventory {
        get {
            return inventory;
        }
    }

    public void ExecuteDialogue()
    {
        KaraokeController.Instance.PlayDialogues(fullDialogue);
    }

    public void UpdateState(IActorNPC actorToUpdate, int newState)
    {
        for(int i = 0; i < actors.Length; i++)
        {
            if(actors[i].Equals(actorToUpdate))
            {
                Debug.Log("Change state");
                states[i] = newState;
                break;
            }
        }

        CheckForStates();
    }

    // CHECK FOR NUMBER OF NPCS GIFTED
    private void CheckForStates() 
    {
        for(int i = 0; i < states.Length; i++)
        {
            if(states[i] == 0)
            {
                return;
            }
        }

        //WIN EVENT
    }
}