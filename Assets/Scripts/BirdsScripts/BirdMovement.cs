using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Vector2 enemyPos;
    public float speed;

    GameObject player;
    Vector3 dir;

    private void Start()
    {
        enemyPos = transform.position;
    }
    private void Update()
    {
        enemyPos = new Vector2(enemyPos.x + (-speed * Time.deltaTime), enemyPos.y);
        transform.position = enemyPos;
    }
}
