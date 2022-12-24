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
    [SerializeField] TMP_Text erkenFinalText;
    [SerializeField] string[] erkenFinalSentences;
    [SerializeField] float writeSpeed;
    [SerializeField] GameObject continueButtonSanta;
    [SerializeField] GameObject continueButtonHero;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject startDialogueButton;
    [SerializeField] GameObject ilgilen;
    [SerializeField] GameObject ilgilenme;
    [SerializeField] GameObject erkenFinalButton;
    [SerializeField] GameObject santa;
    [SerializeField] GameObject kurye;

    int santaIndex, heroIndex, erkenFinalIndex;

    private void Update()
    {
        Debug.Log(santaIndex);
        if(santaText.text == santaSentences[santaIndex])
        {
            if (santaIndex == 4)
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
        if(erkenFinalText.text == erkenFinalSentences[erkenFinalIndex])
        {
            erkenFinalButton.SetActive(true);
        }
    }
    IEnumerator ErkenFinal()
    {
        foreach(char letter in erkenFinalSentences[erkenFinalIndex].ToCharArray())
        {
            erkenFinalText.text += letter;
            yield return new WaitForSeconds(writeSpeed);
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
        santa.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, 0.35f);
        kurye.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, 0.7f);
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
        kurye.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, 0.35f);
        santa.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, 0.7f);
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
        kurye.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0,0,0.35f);
        StartCoroutine(Santa());
        startDialogueButton.SetActive(false);
    }
    public void Ilgilenme()
    {
        santaText.text = "";
        kurye.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, 0.35f);
        santa.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, 0.7f);
        StartCoroutine(ErkenFinal());
        ilgilen.SetActive(false);
        ilgilenme.SetActive(false);
    }
    public void ErkenFinalExit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
