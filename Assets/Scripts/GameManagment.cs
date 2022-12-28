using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    public GameObject oldun;
    public GameObject ruhbitti;
    bool acikmi;
    bool acikmi2;
    private void Start() 
    {
        Time.timeScale = 1;
        oldun.SetActive(false);
        ruhbitti.SetActive(false);
        GiftToHouse.score = 0;
        Application.targetFrameRate = 60;
    }
    private void Update() 
    {
        if (ChristmasSpirit.spirit <= 0)
        {
            if (!acikmi)
            {
                acikmi = true;
                ruhbitti.SetActive(true);
                Invoke(nameof(Durdur), 2);
            }
            
            
            
        }
        if (PlayerMovement.health <=0)
        {
            if (!acikmi2)
            {
                acikmi2 = true;
                oldun.SetActive(true);
                Durdur();
                
            }
            
            
        }
    }


    public void Durdur()
    {
        Time.timeScale = 0;
    }


}
