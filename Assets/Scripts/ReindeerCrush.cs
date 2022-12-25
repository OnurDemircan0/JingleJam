using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReindeerCrush : MonoBehaviour
{
    bool hurt = false;
    bool immunity = true;

    private void Update()
    {
        Debug.Log(immunity);
        if (hurt)
        {
            if (immunity)
            {
                immunity = false;
                PlayerMovement.health--;
                StartCoroutine(Immunity());
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log(PlayerMovement.health);
            hurt = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Immunity()
    {
        yield return new WaitForSeconds(4f);
        immunity = true;
    }

}
