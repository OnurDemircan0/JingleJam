using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TMP_Text santaText;
    [SerializeField] string[] santaSentences;
    [SerializeField] TMP_Text heroText;
    [SerializeField] string[] heroSentences;
    [SerializeField] float writeSpeed;
    [SerializeField] GameObject continueButtonSanta;
    [SerializeField] GameObject continueButtonHero;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject startDialogueButton;
    [SerializeField] GameObject ilgilen;
    [SerializeField] GameObject ilgilenme;

    int santaIndex, heroIndex;

    private void Update()
    {
        Debug.Log(santaIndex);
        if(santaText.text == santaSentences[santaIndex])
        {
            if (santaIndex == 1)
            {
                ilgilen.SetActive(true);
                ilgilenme.SetActive(true);
            }
            else
            {
                continueButtonSanta.SetActive(true);
            }
            
        }
        if(heroText.text == heroSentences[heroIndex])
        {
            continueButtonHero.SetActive(true);
        }
    }

    IEnumerator Santa()
    {
        foreach(char letter in santaSentences[santaIndex].ToCharArray())
        {
            santaText.text += letter;
            yield return new WaitForSeconds(writeSpeed);
        }
    }
    IEnumerator Hero()
    {
        foreach(char letter in heroSentences[heroIndex].ToCharArray())
        {
            heroText.text += letter;
            yield return new WaitForSeconds(writeSpeed);
        }
    }
    public void NextSentenceSanta()
    {
        continueButtonSanta.SetActive(false);
        ilgilen.SetActive(false);
        ilgilenme.SetActive(false);

        if(santaIndex < santaSentences.Length - 1)
        {
            santaText.text = "" ;
            StartCoroutine(Hero());
            santaIndex++;
        }
        else
        {
            santaText.text = "" ;
            StartCoroutine(Hero());
        }
    }
    public void NextSentencesHero()
    {
        continueButtonHero.SetActive(false);
        
    
        if (heroIndex < heroSentences.Length - 1)
        {
            heroText.text = "";
            StartCoroutine(Santa());
            heroIndex++;
        }
        else
        {
            heroText.text = "";
            startGameButton.SetActive(true);
        }
    }
    public void StartDialogue()
    {
        StartCoroutine(Santa());
        startDialogueButton.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
