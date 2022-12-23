using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftandWaterPooling : MonoBehaviour
{
    [SerializeField] List<GameObject> gifts = new List<GameObject>();
    GameObject sentGift;

    [SerializeField] List<GameObject> waterBottles = new List<GameObject>();
    GameObject sentWaterBottle;

    [SerializeField] Transform spawnerPos;

    int random;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GiftSpawn();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            WaterBottleSpawn();
        }
    }

    #region GiftSpawner

    public void GiftSpawn()
    {
        random = Random.Range(0,3);
        sentGift = gifts[random];
        gifts.RemoveAt(random);
        GetGift();
        
    }

    public void GetGift()
    {
        sentGift.SetActive(true);
        sentGift.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10;
        gifts.Add(sentGift);
        sentGift.transform.position = spawnerPos.position;
    }
    #endregion

    #region WaterBottleSpawner
    public void WaterBottleSpawn()
    {
        sentWaterBottle = waterBottles[0];
        waterBottles.RemoveAt(0);
        GetWaterBottle();
    }

    public void GetWaterBottle()
    {
        sentWaterBottle.SetActive(true);
        sentWaterBottle.GetComponent<Rigidbody2D>().velocity = Vector2.right * 15;
        waterBottles.Add(sentWaterBottle);
        sentWaterBottle.transform.position = spawnerPos.position;
    }
    #endregion

}
