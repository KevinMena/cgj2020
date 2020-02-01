using UnityEngine;

public class KaraokeTest : MonoBehaviour
{
    public Dialogue dialogue;

    public void Test()
    {
        KaraokeController.Instance.PlayDialogues(dialogue);
    }
}