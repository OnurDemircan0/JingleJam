using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReindeerCrush : MonoBehaviour
{
    
    public static int damacanaSarjor;

    SpriteRenderer sRend;

    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();

        damacanaSarjor = 0;
    }
    /*
    private void Update()
    {
        
        if (Crush.immunity)
        {
            sRend.color = new Color(sRend.color.r, sRend.color.g, sRend.color.b, 0.4f);
        }
        else
        {
            sRend.color = new Color(sRend.color.r, sRend.color.g, sRend.color.b, 1f);
        }

    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerMovement.health--;
            /*
            if (Crush.canHurt)
            {
                Crush.immunity = true;
            }*/

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Perk"))
        {
            damacanaSarjor++;
            Destroy(collision.gameObject);
        }
    }
   
}
