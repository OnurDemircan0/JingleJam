using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiftToHouse : MonoBehaviour
{
    public static int score = 0;    
    
    private void Start() 
    {
    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Gift"))
        {
            score++;
        }
    }
}
