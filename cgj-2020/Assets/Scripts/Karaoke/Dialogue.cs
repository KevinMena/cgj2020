using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]

public class Dialogue : ScriptableObject
{
    [SerializeField]
    private string[] text = new string[0];

    [SerializeField]
    private float rate = 1;

    [SerializeField]
    private int charPerRate = 1;

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
