using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiftToHouse : MonoBehaviour
{
    public static int score;
    
   
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Gift"))
        {
            score++;
            if (ChristmasSpirit.spirit < 100)
            {
                ChristmasSpirit.spirit += 10;
            }
            
        }
    }
}
