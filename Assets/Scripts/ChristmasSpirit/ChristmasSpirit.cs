using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChristmasSpirit : MonoBehaviour
{
    public static float spirit = 100;
    float fallingTime = 1;
    [SerializeField] TMP_Text spiritText;

    private void Start() 
    {
        InvokeRepeating("FallingSpirit",1,fallingTime);
    }

    

    private void Update() 
    {
        if(GiftToHouse.score > 10 && GiftToHouse.score < 20)
        {
            fallingTime = 0.8f;
        }
        else if(GiftToHouse.score > 20 && GiftToHouse.score < 30)
        {
            fallingTime = 0.6f;
        }
        spiritText.text = spirit.ToString();
    }
    public void FallingSpirit()
    {
        spirit--;
    }
}
