using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Canvas fadeCanvas;

    public Transform tpPoint;

    void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(TpCharacter(col.transform));
    }

    private IEnumerator TpCharacter(Transform character)
    {
        fadeCanvas.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.5f);
        character.position = tpPoint.position;
    }
}
