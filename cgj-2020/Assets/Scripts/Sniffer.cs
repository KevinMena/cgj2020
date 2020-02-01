using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniffer : MonoBehaviour
{
    [SerializeField] const int RAYCAST_LENGTH = 2;

    PlayerMovement playerMovement;

    void Awake() 
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Sniff()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerMovement.lastDirection, RAYCAST_LENGTH);

        if(hit.collider != null) 
        {
            if(hit.transform.tag.Equals("Interactable"))
            {
                Debug.Log("Am hitting");
                hit.transform.GetComponent<Interactable>().InteractWith();
            }
        }
    }
}
