using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftToBadHouse : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Gift"))
        {
            if (ChristmasSpirit.spirit < 100)
            {
                ChristmasSpirit.spirit -= 10;
            }
            
        }
    }
}
