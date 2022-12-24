using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingEffect : MonoBehaviour
{
    Vector3 firstScale;
    bool disappear = false;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        firstScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (disappear)
        {
            rb2d.simulated = false;
            transform.localScale *= 40f * Time.deltaTime;
            StartCoroutine(ResetDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chimney"))
        {
            disappear = true;
        }
    }

    IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(0.3f); //Buradaki süre gift spawn etme delay i ile ayný olacak.
        gameObject.SetActive(false);
        disappear = false;
        transform.localScale = firstScale;
        rb2d.simulated = true;
    }

}
