using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement1 : MonoBehaviour
{
    GameObject player;
    Vector3 dir;

    private void Start()
    {
        player = PlayerMovement.frontReindeer;
        dir = (new Vector3(player.transform.position.x, player.transform.position.y, 0f) - transform.position).normalized;
    }
    private void Update()
    {
        transform.position = transform.position + (dir / 7f);
    }
}
