using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] string[] dialogueSentences;
    [SerializeField] float writeSpeed;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject startGameButton;

    int index;

    private void Start()
    {
        StartCoroutine(Yaz());
    }
    private void Update()
    {
        if(dialogueText.text == dialogueSentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Yaz()
    {
        foreach(char letter in dialogueSentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(writeSpeed);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < dialogueSentences.Length - 1)
        {
            index++;
            dialogueText.text = "" ;
            StartCoroutine(Yaz());
        }
        else
        {
            dialogueText.text = "" ;
            continueButton.SetActive(false);
            startGameButton.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
