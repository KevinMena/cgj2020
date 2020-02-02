using UnityEngine;
using System.Collections;
using System;

public class GameManager : Singleton <GameManager>
{
    public GameObject[] actors;
    [SerializeField] int[] states;

    private int language = 0;

    public int Language {
        get {
            return language;
        }
    }

    public void UpdateState(GameObject actorToUpdate, int newState)
    {
        for(int i = 0; i < actors.Length; i++)
        {
            if(actors.Equals(actorToUpdate))
            {
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