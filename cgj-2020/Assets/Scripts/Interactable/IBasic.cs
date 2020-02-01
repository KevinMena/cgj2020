using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBasic : Interactable
{
    public Dialogue description;

    public override IEnumerator InteractWith() 
    {
        KaraokeController.Instance.PlayDialogues(description);
        yield return null;
    }
}
