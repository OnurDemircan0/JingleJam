using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamacanaSarjor : MonoBehaviour
{
    void Update()
    {
        switch (ReindeerCrush.damacanaSarjor)
        {
            case 4: ReindeerCrush.damacanaSarjor = 3;
                break;
            case 3:
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 0:
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case -1: ReindeerCrush.damacanaSarjor = 0;
                break;
            default:
                break;
        }
    }
}
