using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField] Image sImage = null;
    [SerializeField] Collider2D c = null;
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

    public bool IsRaycasted()
    {
        //RaycastHit2D[] results;
        
        //if (EventSystem.current.IsPointerOverGameObject())
            //return true;
        //else
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
