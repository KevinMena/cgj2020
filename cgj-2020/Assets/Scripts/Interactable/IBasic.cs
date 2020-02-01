using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBasic : Interactable
{
    public Dialogue description;

    public KaraokeProfile profile;

    public override IEnumerator InteractWith() 
    {
        KaraokeController.Instance.PlayDialogue(profile, description);
        yield return null;
    }
}
