using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiftToHouse : MonoBehaviour
{
    int score;    
    public TMP_Text scoreText;
    private void Start() 
    {
    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Gift"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
