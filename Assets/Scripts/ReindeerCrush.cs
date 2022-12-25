using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReindeerCrush : MonoBehaviour
{
    public static bool canHurt = true;
    static bool immunity = false;
    public static int damacanaSarjor = 0;

    SpriteRenderer sRend;

    bool doOnce = true;
    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //StartCoroutine(Immunity());
        /*if (!canHurt)
        {
            StartCoroutine(Fade());
        }*/

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*
            if (canHurt)
            {
                immunity = true;
            }*/

            PlayerMovement.health--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Perk"))
        {
            damacanaSarjor++;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Immunity()
    {
        if (immunity)
        {
            canHurt = false;
            immunity = false;
            
            yield return new WaitForSeconds(1.5f);
            canHurt = true;
        }
    }

    IEnumerator Fade()
    {
        if (doOnce)
        {
            doOnce = false;
            sRend.color = new Color(sRend.color.r, sRend.color.g, sRend.color.b, 0.4f);
            yield return new WaitForSeconds(1.5f);
            sRend.color = new Color(sRend.color.r, sRend.color.g, sRend.color.b, 1f);
            doOnce = true;
        }
    }

}
