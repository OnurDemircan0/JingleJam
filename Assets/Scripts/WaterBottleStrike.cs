using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottleStrike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Perk"))
        {
            PlayerMovement.health--;
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
        
    }
}
