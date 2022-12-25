using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReindeerCrush : MonoBehaviour
{
    static bool canHurt = true;
    static bool immunity = false;
    public static int damacanaSarjor = 0;

    SpriteRenderer sRend;

    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        StartCoroutine(Immunity());
        Debug.Log(canHurt);
        if (!canHurt)
        {
            sRend.color = new Color(sRend.color.r, sRend.color.g, sRend.color.b, sRend.color.a - 20f * Time.deltaTime);
        }
        else
        {
            sRend.color = new Color(sRend.color.r, sRend.color.g, sRend.color.b, sRend.color.a + 22f * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log(PlayerMovement.health);
            if (canHurt)
            {
                immunity = true;
            }
            

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
            PlayerMovement.health--;
            yield return new WaitForSeconds(1.5f);
            canHurt = true;
            //color.a += 0.5f;
        }
    }


}
