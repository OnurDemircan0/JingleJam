using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGround : MonoBehaviour
{
    public static bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameStarted = true;
        }

        if (gameStarted)
        {
            transform.position = new Vector3(transform.position.x - 10f * Time.deltaTime, transform.position.y, transform.position.z);
        }
        
    }



}
