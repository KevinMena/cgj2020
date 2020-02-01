using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBasic : Interactable
{
    public Dialogue description;

    public KaraokeProfile profile;

    public override void InteractWith() 
    {
        KaraokeController.Instance.PlayDialogue(profile, description);
    }
}
