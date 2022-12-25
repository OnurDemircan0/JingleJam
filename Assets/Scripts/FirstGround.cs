using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGround : MonoBehaviour
{
    public static bool gameStarted = false;

    AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
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
