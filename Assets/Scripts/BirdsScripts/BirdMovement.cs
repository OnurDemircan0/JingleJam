using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Vector2 enemyPos;
    float speed;

    private void Start()
    {
        enemyPos = transform.position;
    }
    private void Update()
    {
        if (GiftToHouse.score >= 0 && GiftToHouse.score <= 5)
        {
            speed = 8;
        }
        else if (GiftToHouse.score >= 6 && GiftToHouse.score <= 10)
        {
            speed = 9f;
        }
        else if (GiftToHouse.score >= 11 && GiftToHouse.score <= 15)
        {
            speed = 10f;
        }
        else if (GiftToHouse.score >= 16 && GiftToHouse.score <= 20)
        {
            speed = 11f;
        }
        else if (GiftToHouse.score >= 21 && GiftToHouse.score <= 25)
        {
            speed = 13;
        }
        
        enemyPos = new Vector2(enemyPos.x + (-speed * Time.deltaTime), enemyPos.y);
        transform.position = enemyPos;
    }
}
