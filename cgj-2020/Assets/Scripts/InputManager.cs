using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] Sniffer sniffer = null;
    [SerializeField] PlayerMovement playerMovement = null;

    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // EF STUFF

        if (Input.GetButtonDown("Fire1"))
        {
            if (KaraokeController.Instance.IsTalking)
            {
                Item i = HotbarController.Instance.IsItemSelected();

                if (i == null)
                    KaraokeController.Instance.SendInterruption();
                else
                {
                    KaraokeController.Instance.IActorNPC.SendGift(InventoryManager.Instance.GetCode(i));
                    GameManager.Instance.Inventory.RemoveItem(i);
                }
            }
            else
            {   
                Debug.Log("Sniffing");
                sniffer.Sniff();
            }
        }

        // AXIS STUFF

        float horizontal = 0f;
        float vertical = 0f;
        animator.SetBool("walking", false);

        if (!KaraokeController.Instance.IsTalking)
        {
            if(Input.GetAxisRaw("Horizontal") != 0) 
            {
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = 0f;
                animator.SetBool("walking", true);
            } 
            else if(Input.GetAxisRaw("Vertical") != 0)
            {
                vertical = Input.GetAxisRaw("Vertical");
                horizontal = 0f;
                animator.SetBool("walking", true);
            }
            Vector3 direction = new Vector3(horizontal, vertical, 0);
            playerMovement.Move(direction);
            animator.SetFloat("moveX", horizontal);
            animator.SetFloat("moveY", vertical);
        }
    }
}
