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

    private bool showKaraoke = true;

    private IActorNPC talkinNPC = null; 
    private bool isMoving = false;

    public bool IsTalking {
        get {
            return isTalking;
        }
    }

    public bool IsMoving {
        set {
            isMoving = value;
        }
    }

    public IActorNPC IActorNPC {
        set {
            talkinNPC = value;
        }

        get {
            return talkinNPC;
        }
    }

    public void PlayDialogues(Dialogue msg)
    {
        PlayDialogues(new Dialogue[] {msg});
    }

    public void PlayDialogues(Dialogue[] msgs)
    {
        if (isTalking)
            showKaraoke = false;


        isTalking = true;
        cDialogues = msgs;

        StartCoroutine(ExecuteDialog());
    }

    private IEnumerator SetPortrait(KaraokeProfile kp)
    {
        if (kp != lastKaraokeProfile)
        {   
            if (lastKaraokeProfile != null)
            {
                animator.SetTrigger("HidePortrait");
                yield return new WaitForSeconds(.5f);
            }
            lastKaraokeProfile = kp;
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
            if (showKaraoke)
                animator.SetTrigger("Show");
            yield return new WaitForSeconds(.25f);
            yield return StartCoroutine(SetPortrait(cDialogues[i].KaraokeProfile));
            yield return new WaitForSeconds(.5f);

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
            isDone = true;
        }
    } 

    private void EndDialogue()
    {   
        Debug.Log("Ending Dialogue");
        isTalking = false;
        lastKaraokeProfile = null;

        if (isMoving)
            talkinNPC.isMoving = true;


        showKaraoke = true;
        talkinNPC = null;
        isMoving = false;
        animator.SetTrigger("HidePortrait");
        animator.SetTrigger("Hide");

    }

    public void SendInterruption()
    {
        if (isDone)
            EndDialogue();
        else
            skip = true;
    }

}
