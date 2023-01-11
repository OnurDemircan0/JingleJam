using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    public static bool canHurt;
    public static bool immunity;


    // Start is called before the first frame update
    void Start()
    {
        canHurt = true;
        immunity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (immunity)
        {
            StartCoroutine(Immunity());
        }

    }

    IEnumerator Immunity()
    {
        if (canHurt)
        {
            canHurt = false;
            yield return new WaitForSeconds(1.5f);
            canHurt = true;
            immunity = false;
        }
    }



}
