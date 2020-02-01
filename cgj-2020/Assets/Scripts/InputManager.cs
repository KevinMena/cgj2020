using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] Sniffer sniffer = null;
    [SerializeField] PlayerMovement playerMovement = null;

    void Update()
    {

        // EF STUFF

        if (Input.GetButton("Fire 1"))
        {
            if (KaraokeController.Instance.IsTalking)
                KaraokeController.Instance.SendInterruption();
            else
            {
                sniffer.Sniff();
            }

        }

        // AXIS STUFF

        float horizontal = 0f;
        float vertical = 0f;

        if (!KaraokeController.Instance.IsTalking)
        {
         if(Input.GetAxisRaw("Horizontal") != 0) 
            {
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = 0f;
            } 
            else if(Input.GetAxisRaw("Vertical") != 0)
            {
                vertical = Input.GetAxisRaw("Vertical");
                horizontal = 0f;
            }

            Vector3 direction = new Vector3(horizontal, vertical, 0);
            playerMovement.Move(direction);

        }
        
    }
}
