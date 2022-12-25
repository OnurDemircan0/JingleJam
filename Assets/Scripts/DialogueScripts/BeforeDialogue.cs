using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeforeDialogue : MonoBehaviour
{
    [SerializeField] TMP_Text sucuText;
    [SerializeField] string[] sucuSentences;
    [SerializeField] float writeSpeed;
    int sucuIndex;
    private void Start()
    {
        StartCoroutine(Sucu());
    }
    IEnumerator Sucu()
    {
        foreach (char letter in sucuSentences[sucuIndex].ToCharArray())
        {
            sucuText.text += letter;
            yield return new WaitForSeconds(writeSpeed);
        }
    }
}
