using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshPro tmPro;

    private void Start()
    {
        StartCoroutine("StartSeq", 3f);
    }

    IEnumerator StartSeq()
    {
        yield return new WaitForSeconds(2f);
        tmPro.text = "Help!";
        yield return new WaitForSeconds(2f);
        tmPro.text = "It seems you're stuck?";
        StartCoroutine("StartSeq");
    }
}
