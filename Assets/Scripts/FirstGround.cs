using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGround : MonoBehaviour
{
    public static bool gameStarted = false;

    

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameStarted = true;
        }
        Debug.Log(gameStarted + "gameStarted");
        
    }



}
