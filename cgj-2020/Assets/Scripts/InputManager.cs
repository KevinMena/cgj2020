using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire 1"))
        {
            if (KaraokeController.Instance.IsTalking)
                KaraokeController.Instance.SendInterruption();
        }
    }
}
