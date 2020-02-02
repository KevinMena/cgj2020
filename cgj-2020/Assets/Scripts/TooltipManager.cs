using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TooltipManager : Singleton<TooltipManager> 
{
    [SerializeField] TMP_Text text = null;
    [SerializeField] Animator animator = null;

    bool isOn = false;

    public void Show(Item i)
    {
        if (!isOn)
            return;

        isOn = true;
        text.text = i.itemDescription;
        animator.SetTrigger("Show");
    } 

    public void Hide()
    {
        isOn = false;
        animator.SetTrigger("Hide");
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }
}