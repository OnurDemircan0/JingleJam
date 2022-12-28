using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScripts : MonoBehaviour
{
    public GameObject oldun;
    public GameObject ruhbitti;
    private void Start() 
    {
        Time.timeScale = 1;
    }
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

    public void Restart()
    {
        Time.timeScale = 1;
        oldun.SetActive(false);
        ruhbitti.SetActive(false);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void AnaMenu()
    {
        Time.timeScale = 1;
        oldun.SetActive(false);
        ruhbitti.SetActive(false);
        SceneManager.LoadScene("EntryScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
