using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] reindeers;
    public static GameObject frontReindeer;

    Vector3 dir1;
    Vector3 dir2;
    Vector3 dir3;

    public float rotSpeed = 40;
    float angle = 0f;

    public float dSpeed = 40; // disappearing speed
    Vector3 firstScale = new Vector3(1, 1, 1);

    public static int health = 3;

    public static bool canMove = false;

    public static float time = 0f;

    float frontReindeerPosY;

    private void Start()
    {
        frontReindeer = reindeers[2];
    }

    // Update is called once per frame
    void Update()
    {
        if(health != 0)
        {
            if (health > 0)
            {
                float maxY1 = Mathf.Abs(reindeers[0].transform.position.y - transform.position.y); // Önündeki karakterin y ekseni ile kendi y ekseni arasýndaki farkýn mutlak deðerini buluyor. Bu deðeri karakter önündekinden ne kadar uzaksa o kadar hýzlý hareket etsin diye atadýk.
                dir1 = (new Vector3(transform.position.x, reindeers[0].transform.position.y, 0f) - transform.position).normalized; // Burada objenin y ekseninin önündekiyle eþit olacaðý zaman durmasýný saðlayacak bir birim vektör tanýmlýyoruz.
                transform.position = transform.position + (dir1 / 7f * maxY1); // Karakter y ekseninde hareket ediyor. Eeðer önündeki karakterin y ekseni ile eþit ise duruyor.
                transform.position = new Vector3(reindeers[0].transform.position.x - 1f, transform.position.y, 0f); // Karakterin önündeki karakter ile mesafesini koruyor.
            }

            if (health > 1)
            {
                float maxY2 = Mathf.Abs(reindeers[1].transform.position.y - reindeers[0].transform.position.y);
                dir2 = (new Vector3(reindeers[0].transform.position.x, reindeers[1].transform.position.y, 0f) - reindeers[0].transform.position).normalized;
                reindeers[0].transform.position = reindeers[0].transform.position + (dir2 / 7f * maxY2);
                reindeers[0].transform.position = new Vector3(reindeers[1].transform.position.x - 0.8f, reindeers[0].transform.position.y, 0f);
            }

            if (health > 2)
            {
                float maxY3 = Mathf.Abs(reindeers[2].transform.position.y - reindeers[1].transform.position.y);
                dir3 = (new Vector3(reindeers[1].transform.position.x, reindeers[2].transform.position.y, 0f) - reindeers[1].transform.position).normalized;
                reindeers[1].transform.position = reindeers[1].transform.position + (dir3 / 7f * maxY3);
                reindeers[1].transform.position = new Vector3(reindeers[2].transform.position.x - 0.8f, reindeers[1].transform.position.y, 0f);
            }


            //frontReindeer.transform.position += frontReindeer.transform.TransformDirection(Vector3.right).normalized / 500f;
            frontReindeer = reindeers[health - 1];
            frontReindeerPosY = frontReindeer.transform.position.y;
            if (canMove)
            {
                if (Input.GetKey(KeyCode.UpArrow) && frontReindeerPosY < 4.1f)
                {
                    time = 0;
                    angle += rotSpeed * Time.deltaTime;
                    frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                    frontReindeer.transform.position = new Vector3(frontReindeer.transform.position.x, frontReindeer.transform.position.y + 4f * Time.deltaTime, 0f);
                }
                else if (Input.GetKey(KeyCode.DownArrow) && frontReindeerPosY > -1.2f)
                {
                    time = 0;
                    angle -= rotSpeed * Time.deltaTime;
                    frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                    frontReindeer.transform.position = new Vector3(frontReindeer.transform.position.x, frontReindeer.transform.position.y - 4f * Time.deltaTime, 0f);
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
                frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                frontReindeer.transform.position = new Vector3(frontReindeer.transform.position.x, frontReindeer.transform.position.y + 2.5f * Time.deltaTime, 0f);
                angle = Mathf.Clamp(angle, -10f, 10f);
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
        }
        else
        {
            reindeers[2].SetActive(false);
            reindeers[1].SetActive(false);
            StartCoroutine(Disappear(0));
            reindeers[2].transform.position = new Vector3(reindeers[1].transform.position.x + 0.8f, reindeers[1].transform.position.y, 0f);
            reindeers[1].transform.position = new Vector3(reindeers[0].transform.position.x + 0.8f, reindeers[0].transform.position.y, 0f);
            reindeers[0].transform.position = new Vector3(transform.position.x + 1f, transform.position.y, 0f);
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

}
