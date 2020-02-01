using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    public string itemName = "New item";

    [TextArea(4, 8)]
    public string itemDescription = "New description";

    public Sprite itemImage;
}
