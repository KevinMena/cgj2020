using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KaraokeController : Singleton<KaraokeController>
{
    
    [SerializeField]
    private Image kPortrait;

    [SerializeField]
    private TMP_Text kText;

    [SerializeField]
    private AudioSource kAudioS;

    private CanvasRenderer textCR;
    private float rate = 0;

    private bool skip = false;
    private bool isTalking = false;

    public bool IsTalking {
        get {
            return isTalking;
        }
    }

    public void PlayDialogue(KaraokeProfile karaokeProfile, Dialogue msg)
    {
        isTalking = true;
        kText.text = msg.GetString(GameManager.Instance.Language);
        kPortrait.sprite = karaokeProfile.Portrait;
        kText.maxVisibleCharacters = 0;
        StartCoroutine(ExecuteDialog(msg.Rate, msg.CharPerRate, karaokeProfile.Voice));
    }

    private IEnumerator ExecuteDialog (float rate, int charPerRate, AudioClip audioClip)
    {
        int msgLength = kText.text.Length;
        
        for (int i = 0; i < msgLength; i++)
        {
            if (skip)
                kText.maxVisibleCharacters = msgLength;
            else
                kText.maxVisibleCharacters += charPerRate;
            
            kAudioS.PlayOneShot(audioClip);
            yield return new WaitForSeconds(rate);
        }

        isTalking = false;
        skip = false;
    } 

    public void SendInterruption()
    {
        skip = true;
    }

}
