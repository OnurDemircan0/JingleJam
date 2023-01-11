using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] reindeers;
    public static GameObject frontReindeer;

    AudioSource audioS;
    bool doOnce2 = true;

    Vector3 dir1;
    Vector3 dir2;
    Vector3 dir3;

    public float rotSpeed = 40;
    float angle = 0f;

    public float dSpeed = 40; // disappearing speed
    Vector3 firstScale = new(1, 1, 1);

    public static int health = 3;

    public static bool canMove;

    public static float time = 0f;

    float frontReindeerPosY;

    SpriteRenderer sRend;
    bool doOnce = true;

    float catchSpeed;
    float speed;

    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        audioS = GetComponent<AudioSource>();

        canMove = false;
        frontReindeer = reindeers[2];
        health = 3;
        catchSpeed = 7.04f;
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GiftToHouse.score > 5)
        {
            catchSpeed = 6.4f;
            speed = 4.8f;
        }
        if(GiftToHouse.score > 10)
        {
            catchSpeed = 5.76f;
            speed = 5.6f;
        }
        if (GiftToHouse.score > 15)
        {
            catchSpeed = 5.12f;
            speed = 6.4f;
        }
        if (GiftToHouse.score > 20)
        {
            catchSpeed = 4.48f;
            speed = 7.2f;
        }
        if (GiftToHouse.score > 25)
        {
            catchSpeed = 3.84f;
            speed = 8f;
        }
        if (GiftToHouse.score > 30)
        {
            catchSpeed = 3.2f;
            speed = 8.8f;
        }

        if (health != 0)
        {
            if (health > 0)
            {
                float maxY1 = Mathf.Abs(reindeers[0].transform.position.y - transform.position.y); // Önündeki karakterin y ekseni ile kendi y ekseni arasýndaki farkýn mutlak deðerini buluyor. Bu deðeri karakter önündekinden ne kadar uzaksa o kadar hýzlý hareket etsin diye atadýk.
                dir1 = (new Vector3(transform.position.x, reindeers[0].transform.position.y, 0f) - transform.position).normalized; // Burada objenin y ekseninin önündekiyle eþit olacaðý zaman durmasýný saðlayacak bir birim vektör tanýmlýyoruz.
                transform.position = transform.position + (dir1 / catchSpeed * maxY1); // Karakter y ekseninde hareket ediyor. Eeðer önündeki karakterin y ekseni ile eþit ise duruyor.
                transform.position = new Vector3(reindeers[0].transform.position.x - 1f, transform.position.y, 0f); // Karakterin önündeki karakter ile mesafesini koruyor.
            }

            if (health > 1)
            {
                float maxY2 = Mathf.Abs(reindeers[1].transform.position.y - reindeers[0].transform.position.y);
                dir2 = (new Vector3(reindeers[0].transform.position.x, reindeers[1].transform.position.y, 0f) - reindeers[0].transform.position).normalized;
                reindeers[0].transform.position = reindeers[0].transform.position + (dir2 / catchSpeed * maxY2);
                reindeers[0].transform.position = new Vector3(reindeers[1].transform.position.x - 0.8f, reindeers[0].transform.position.y, 0f);
            }

            if (health > 2)
            {
                float maxY3 = Mathf.Abs(reindeers[2].transform.position.y - reindeers[1].transform.position.y);
                dir3 = (new Vector3(reindeers[1].transform.position.x, reindeers[2].transform.position.y, 0f) - reindeers[1].transform.position).normalized;
                reindeers[1].transform.position = reindeers[1].transform.position + (dir3 / catchSpeed * maxY3);
                reindeers[1].transform.position = new Vector3(reindeers[2].transform.position.x - 0.8f, reindeers[1].transform.position.y, 0f);
            }


            //frontReindeer.transform.position += frontReindeer.transform.TransformDirection(Vector3.right).normalized / 500f;
            frontReindeer = reindeers[health - 1];
            frontReindeerPosY = frontReindeer.transform.position.y;
            if (canMove)
            {
                audioS.volume -= 0.005f;
                if (Input.GetKey(KeyCode.UpArrow) && frontReindeerPosY < 4.1f)
                {
                    time = 0;
                    angle += rotSpeed * Time.deltaTime;
                    frontReindeer.transform.SetPositionAndRotation(new Vector3(frontReindeer.transform.position.x, frontReindeer.transform.position.y + speed * Time.deltaTime, 0f), Quaternion.Euler(0f, 0f, angle));
                }
                else if (Input.GetKey(KeyCode.DownArrow) && frontReindeerPosY > -1.2f)
                {
                    time = 0;
                    angle -= rotSpeed * Time.deltaTime;
                    frontReindeer.transform.SetPositionAndRotation(new Vector3(frontReindeer.transform.position.x, frontReindeer.transform.position.y - speed * Time.deltaTime, 0f), Quaternion.Euler(0f, 0f, angle));
                }
                else
                {
                    time += Time.deltaTime;
                    if (angle > 0.1)
                    {
                        angle -= rotSpeed * Time.deltaTime;
                        frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                    }
                    else if (angle < -0.1)
                    {
                        angle += rotSpeed * Time.deltaTime;
                        frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                    }
                    else
                    {
                        angle = 0;
                        frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                    }
                }
            }
            else if (!canMove && FirstGround.gameStarted)
            {
                StartCoroutine(MoveDelay());
                angle += 17f * Time.deltaTime;
                frontReindeer.transform.SetPositionAndRotation(new Vector3(frontReindeer.transform.position.x, frontReindeer.transform.position.y + 2.5f * Time.deltaTime, 0f), Quaternion.Euler(0f, 0f, angle));
                angle = Mathf.Clamp(angle, -10f, 10f);
                StartCoroutine(BellAudio());
            }

            // Burasý objelerin bir önündeki objeye bakmasýný saðlýyo.
            if (health > 0)
            {
                transform.right = reindeers[0].transform.position - transform.position;
            }
            if (health > 1)
            {
                reindeers[0].transform.right = reindeers[1].transform.position - reindeers[0].transform.position;
            }
            if (health > 2)
            {
                reindeers[1].transform.right = reindeers[2].transform.position - reindeers[1].transform.position;
            }

            angle = Mathf.Clamp(angle, -17f, 17f);

            if (health == 3)
            {
                reindeers[2].SetActive(true);
                reindeers[1].SetActive(true);
                reindeers[0].SetActive(true);
                reindeers[2].transform.localScale = firstScale;
                reindeers[1].transform.localScale = firstScale;
                reindeers[0].transform.localScale = firstScale;
            }
            else if (health == 2)
            {
                StartCoroutine(Disappear(2));
                reindeers[1].SetActive(true);
                reindeers[0].SetActive(true);
                reindeers[1].transform.localScale = firstScale;
                reindeers[0].transform.localScale = firstScale;
                reindeers[2].transform.position = new Vector3(reindeers[1].transform.position.x + 0.8f, reindeers[1].transform.position.y, 0f);
            }
            else if (health == 1)
            {
                reindeers[2].SetActive(false);
                StartCoroutine(Disappear(1));
                reindeers[0].SetActive(true);
                reindeers[2].transform.localScale *= (dSpeed * Time.deltaTime);
                reindeers[0].transform.localScale = firstScale;
                reindeers[2].transform.position = new Vector3(reindeers[1].transform.position.x + 0.8f, reindeers[1].transform.position.y, 0f);
                reindeers[1].transform.position = new Vector3(reindeers[0].transform.position.x + 0.8f, reindeers[0].transform.position.y, 0f);
            }

            if (!ReindeerCrush.canHurt)
            {
                StartCoroutine(Fade());
            }
        }
        else
        {
            reindeers[2].SetActive(false);
            reindeers[1].SetActive(false);
            StartCoroutine(Disappear(0));
            reindeers[2].transform.position = new Vector3(reindeers[1].transform.position.x + 0.8f, reindeers[1].transform.position.y, 0f);
            reindeers[1].transform.position = new Vector3(reindeers[0].transform.position.x + 0.8f, reindeers[0].transform.position.y, 0f);
            reindeers[0].transform.position = new Vector3(transform.position.x + 1f, transform.position.y, 0f);
            if (!GetComponent<Rigidbody2D>())
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
        }

    }

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(2f);
        canMove = true;
    }

    IEnumerator Disappear(int i)
    {
        reindeers[i].transform.localScale *= (dSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        reindeers[i].SetActive(false);
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

    IEnumerator BellAudio()
    {
        if (doOnce2)
        {
            doOnce2 = false;
            audioS.Play();
            yield return new WaitForSeconds(2f);
            doOnce2 = true;
        }
    }

}
