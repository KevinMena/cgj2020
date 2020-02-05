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
        if (isOn)
            return;

        isOn = true;
        text.text = i.itemDescription;
        animator.SetBool("Show", true);
    } 

    public void Hide()
    {
        isOn = false;
        animator.SetBool("Show", false);
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }
}