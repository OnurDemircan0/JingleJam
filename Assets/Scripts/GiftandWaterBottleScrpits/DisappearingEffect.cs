using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingEffect : MonoBehaviour
{
    Vector3 firstScale;
    bool disappear;
    bool grounded;

    AudioSource audioS;
    public AudioClip audioC1;
    public AudioClip audioC2;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
        firstScale = transform.localScale;

        disappear = false;
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (disappear)
        {
            rb2d.simulated = false;
            transform.localScale *= (40f * Time.deltaTime);
            StartCoroutine(ResetDelay());
        }
        if(grounded)
        {
            transform.position = new Vector3(transform.position.x - 5f * Time.deltaTime, transform.position.y,transform.position.z);
            StartCoroutine(ResetDelay2());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chimney"))
        {
            disappear = true;
            audioS.clip = audioC1;
            audioS.Play();
        }
        else if(collision.CompareTag("Ground"))
        {
            grounded = true;
            ChristmasSpirit.spirit -= 10;
            rb2d.simulated = false;
            audioS.clip = audioC2;
            audioS.Play();
        }
    }

    IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(0.3f); //Buradaki s�re gift spawn etme delay i ile ayn� olacak.
        gameObject.SetActive(false);
        disappear = false;
        transform.localScale = firstScale;
        rb2d.simulated = true;
    }
    IEnumerator ResetDelay2()
    {
        yield return new WaitForSeconds(0.3f); //Buradaki s�re gift spawn etme delay i ile ayn� olacak.
        gameObject.SetActive(false);
        grounded = false;
        rb2d.simulated = true;
    }
}
