using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TooltipManager : MonoBehaviour 
{
    [SerializeField] TMP_Text text = null;
    [SerializeField] Animator animator = null;

    public void SetTooltip(Item i)
    {
        text.text = i.itemDescription;
        animator.SetTrigger("Show");
    } 

    void Update()
    {
        bool showing = false;
        for (int i = 0; i <  HotbarController.Instance.nSlots; i++)
        {
            if (!HotbarController.Instance.Slots[i].isEmpty && HotbarController.Instance.Slots[i].IsRaycasted())
            {
                transform.position = Input.mousePosition;
                SetTooltip(HotbarController.Instance.Slots[i].Item);
                showing = true;
            }    
        }

        if (!showing)
        {
            animator.SetTrigger("Hide");
        }
        
    }
}