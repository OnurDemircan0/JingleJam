using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gift"))
        {
            if (ChristmasSpirit.spirit <= 100)
            {
                ChristmasSpirit.spirit -= 10;
            }
        }
    }
}
