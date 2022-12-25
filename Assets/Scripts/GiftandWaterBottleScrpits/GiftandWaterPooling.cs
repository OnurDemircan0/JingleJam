using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiftandWaterPooling : MonoBehaviour
{
    [SerializeField] List<GameObject> gifts = new List<GameObject>();
    GameObject sentGift;

    [SerializeField] List<GameObject> waterBottles = new List<GameObject>();
    GameObject sentWaterBottle;

    [SerializeField] Transform spawnerPos;
    public TMP_Text scoreText;

    int random;

    bool canSpawn = true;
    
    void Update()
    {
        scoreText.text=GiftToHouse.score.ToString();

        if (PlayerMovement.canMove)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                StartCoroutine(SpawnDelay());
            }
            if (Input.GetKeyDown(KeyCode.F) && ReindeerCrush.damacanaSarjor > 0)
            {
                WaterBottleSpawn();
                ReindeerCrush.damacanaSarjor--;
            }
        }
        
    }

    IEnumerator SpawnDelay()
    {
        if (canSpawn)
        {
            canSpawn = false;
            GiftSpawn();
            yield return new WaitForSeconds(0.3f);
            canSpawn = true;
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
        sentWaterBottle.GetComponent<Rigidbody2D>().velocity = Vector2.right * 7;
        sentWaterBottle.GetComponent<Rigidbody2D>().AddTorque(-800);
        waterBottles.Add(sentWaterBottle);
        sentWaterBottle.transform.position = spawnerPos.position;
    }
    #endregion

}
