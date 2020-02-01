using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerialiazeField] Image sImage = null;
    private Item myItem = null;

    public Item Item {
        get {
            return myItem;
        }

        set {
            myItem = value;
            sImage.sprite = Item.itemImage;
        }
    }

} 
