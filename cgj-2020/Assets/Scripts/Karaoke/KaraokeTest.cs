using UnityEngine;

public class KaraokeTest : MonoBehaviour
{
    public Dialogue dialogue;
    public KaraokeProfile karaokeProfile;

    public void Test()
    {
        KaraokeController.Instance.PlayDialogue(karaokeProfile, dialogue);
    }
}