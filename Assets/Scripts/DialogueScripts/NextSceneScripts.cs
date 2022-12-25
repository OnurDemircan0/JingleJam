using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScripts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Motor"))
        {
            SceneManager.LoadScene("DialogueScene");
        }
    }
    public void OyunaBasla()
    {
        SceneManager.LoadScene("BeforeDialogueScene");
    }
    public void NasilOynanirExit()
    {
        SceneManager.LoadScene("EntryScene");
    }
    public void NasilOynanir()
    {
        SceneManager.LoadScene("NasilOynanirScene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
