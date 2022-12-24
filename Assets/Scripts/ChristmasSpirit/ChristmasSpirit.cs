using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChristmasSpirit : MonoBehaviour
{
    float spirit = 100;
    float fallingTime = 0.1f;
    [SerializeField] TMP_Text spiritText;

    private void Start() 
    {
        InvokeRepeating("FallingSpirit",1,fallingTime);
    }

    

    private void Update() 
    {
        Debug.Log(spirit);
        spiritText.text = spirit.ToString();
    }
    public void FallingSpirit()
    {
        spirit--;
    }
}
