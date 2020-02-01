using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KaraokeProfile", menuName = "KaraokeProfile")]
public class KaraokeProfile : ScriptableObject
{
    [SerializeField]
    private Sprite portrait = null;
    
    [SerializeField]
    private AudioClip voice = null;
    
    public Sprite Portrait {
        get {
            return portrait;
        }
    }

    public AudioClip Voice {
        get {
            return voice;
        }
    }
}
