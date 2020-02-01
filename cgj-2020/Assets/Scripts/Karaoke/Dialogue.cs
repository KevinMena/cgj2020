using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]

public class Dialogue : ScriptableObject
{
    [SerializeField]
    private string[] text;

    [SerializeField]
    private float rate;

    [SerializeField]
    private int charPerRate;

    public float Rate {
        get {
            return rate;
        }
    }

    public int CharPerRate {
        get {
            return charPerRate;
        }
    }

    public string GetString(int LngCode)
    {
        if (LngCode < text.Length)
            return text[LngCode];
        else
            return text[0];
    }
}
