using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    public GameObject oldun;
    public GameObject ruhbitti;
    private void Start() 
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
    }
    private void Update() 
    {
        if (ChristmasSpirit.spirit <= 0)
        {
            ruhbitti.SetActive(true);
            Invoke("Durdur",2);
            
        }
        if (PlayerMovement.health <=0)
        {
            oldun.SetActive(true);
            Durdur();
        }
    }


    public void Durdur()
    {
        Time.timeScale = 0;
    }


}
