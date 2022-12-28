using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChristmasSpirit : MonoBehaviour
{
    public static float spirit = 100;
    float fallingTime;
    [SerializeField] TMP_Text spiritText;

    private void Start() 
    {
        InvokeRepeating(nameof(FallingSpirit), 1,fallingTime);
        spirit = 100;
        fallingTime = 1;
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
        spirit = Mathf.Clamp(spirit, 0, 100);
        spiritText.text = spirit.ToString();
    }
    public void FallingSpirit()
    {
        spirit--;
    }
}
