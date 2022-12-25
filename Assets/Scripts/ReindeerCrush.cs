using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReindeerCrush : MonoBehaviour
{
    static bool canHurt = true;
    static bool immunity = false;
    public static int damacanaSarjor = 0;

    Color color;

    private void Start()
    {
        color = GetComponent<SpriteRenderer>().material.color;
    }

    private void Update()
    {
        StartCoroutine(Immunity());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log(PlayerMovement.health);
            if (canHurt)
            {
                Debug.Log("girdi");
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
            //color.a -= 0.4f;
            yield return new WaitForSeconds(1.5f);
            canHurt = true;
            //color.a += 0.5f;
        }
    }

}
