using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KaraokeController : Singleton<KaraokeController>
{
    
    [SerializeField]
    private Image kPortrait = null;

    [SerializeField]
    private TMP_Text kText = null;

    [SerializeField]
    private AudioSource kAudioS = null;

    [SerializeField]
    private Animator animator = null;

    private bool skip = false;
    private bool isTalking = false;
    private bool isDone = false;

    private Dialogue[] cDialogues = null;

    private KaraokeProfile lastKaraokeProfile = null;

    public bool IsTalking {
        get {
            return isTalking;
        }
    }

    public void PlayDialogues(Dialogue msg)
    {
        PlayDialogues(new Dialogue[] {msg});
    }

    public void PlayDialogues(Dialogue[] msgs)
    {
        isTalking = true;
        cDialogues = msgs;
        animator.SetTrigger("Show");
        StartCoroutine(ExecuteDialog());
    }

    private void SetProfile(KaraokeProfile kp)
    {
        if (kp != lastKaraokeProfile)
        {
            kPortrait.sprite = kp.Portrait;
            animator.SetTrigger("ShowPortrait");
        }
    }
    private IEnumerator ExecuteDialog()
    {
        int lngCode = GameManager.Instance.Language;

        for (int i = 0; i < cDialogues.Length; i++)
        {
            kText.text = cDialogues[i].GetString(lngCode);
            int msgLength = kText.text.Length;   
            kText.maxVisibleCharacters = 0;    
            
            AudioClip voice = cDialogues[i].KaraokeProfile.Voice;
            SetProfile(cDialogues[i].KaraokeProfile);
            int j = 0;
            isDone = false;
            kAudioS.PlayOneShot(cDialogues[i].KaraokeProfile.Voice);

            while (j < msgLength)
            {
                if (skip)
                {
                    kText.maxVisibleCharacters = msgLength;
                }
                else
                {
                    if (kText.maxVisibleCharacters + cDialogues[i].CharPerRate < msgLength)
                    {
                        kText.maxVisibleCharacters += cDialogues[i].CharPerRate;
                    }
                    else
                    {
                        kText.maxVisibleCharacters = msgLength;
                    }
                }

                j = kText.maxVisibleCharacters;
                
                yield return new WaitForSeconds(cDialogues[i].Rate);
            }

            skip = false;

            yield return new WaitUntil(()=>isDone);
            
            isDone = true;
        }
    } 

    private void EndDialogue()
    {
        isTalking = false;
        lastKaraokeProfile = null;
        animator.SetTrigger("HideAll");
    }

    public void SendInterruption()
    {
        if (isDone)
            EndDialogue();
        else
            skip = true;
    }

}
