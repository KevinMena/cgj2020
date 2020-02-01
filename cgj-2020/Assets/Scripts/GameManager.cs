using UnityEngine;
using System.Collections;

public class GameManager : Singleton <GameManager>
{
    private int language = 0;

    public int Language {
        get {
            return language;
        }
    }
}