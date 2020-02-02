using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                sImage.sprite = Item.itemImage;
            else
                sImage.sprite = null;
        }
    }

    public bool IsRaycasted()
    {
        if (sImage.Raycast(Input.mousePosition, Camera.main))
            return true;
        else
            return false;            
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

} 
