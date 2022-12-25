using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGround : MonoBehaviour
{
    public static bool gameStarted = false;
    public GameObject saii ;
    

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
        if (gameStarted == true)
        {
            saii.SetActive(false);
        }
        Debug.Log(gameStarted + "gameStarted");
        
    }



}
