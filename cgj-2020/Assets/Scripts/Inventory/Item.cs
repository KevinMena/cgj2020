using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    public string itemName = "New item";

    public string itemDescription = "New description";

    public GameObject owner;

    public Sprite itemImage;
}
