using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniffer : MonoBehaviour
{
    [SerializeField] const int RAYCAST_LENGTH = 2;

    PlayerMovement playerMovement;

    public LayerMask layerMask;

    private bool currentSniff = false;

    private bool lastSniff = false;

    void Awake() 
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Sniff()
    {
        if(currentSniff == lastSniff) 
        {
            currentSniff = !currentSniff;

            transform.GetComponent<BoxCollider2D>().enabled = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerMovement.lastDirection, RAYCAST_LENGTH);
            transform.GetComponent<BoxCollider2D>().enabled = true;

            if(hit.collider != null) 
            {
                Debug.Log("Hitting");
                if(hit.transform.GetComponent<IItem>() != null)
                {
                    Debug.Log("Am hitting");
                    StartCoroutine(hit.transform.GetComponent<IItem>().InteractWith());
                }
                else if(hit.transform.GetComponent<IActorNPC>() != null) 
                {
                    Debug.Log("Am hitting");
                    StartCoroutine(hit.transform.GetComponent<IActorNPC>().InteractWith());
                }
                else if(hit.transform.GetComponent<IBasic>() != null)
                {
                    Debug.Log("Am hitting");
                    StartCoroutine(hit.transform.GetComponent<IBasic>().InteractWith());
                }
            }

            currentSniff = !currentSniff;
        }
    }
}
