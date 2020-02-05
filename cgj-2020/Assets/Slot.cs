using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField] Image sImage = null;
    private Item myItem = null;

    public Item Item {
        get {
            return myItem;
        }

        set {
            myItem = value;
            
            if (value != null)
            {
                sImage.sprite = Item.itemImage;
                sImage.enabled = true;
            }
            else
            {
                sImage.sprite = null;
                sImage.enabled = false;
            }
        }
    }

    public bool isEmpty {
        get {
            return null == myItem;
        }
    }

    public bool IsSelected()
    {
        if (sImage.Raycast(Input.mousePosition, Camera.main))
            return true;

        return false;
    }

    void OnMouseExit()
    {
        TooltipManager.Instance.Hide();
        HotbarController.Instance.selected = null;
    }

    void OnMouseEnter()
    {

        if (this.isEmpty)
            return;

        
        HotbarController.Instance.selected = this;
        TooltipManager.Instance.Show(myItem);
    }

} 
