using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> houses = new List<GameObject> ();
    GameObject sentHouse;
    float spawnerTime = 4;
    int random;
    
    [SerializeField] Transform spawnerPos;

    private void Start() 
    {
        InvokeRepeating("HouseSpawn",1,spawnerTime);
    }
    private void Update() 
    {
        
        if (GiftToHouse.score >= 0 && GiftToHouse.score <= 5)
        {
            spawnerTime = 4;
        }
        else if (GiftToHouse.score >= 6 && GiftToHouse.score <= 10)
        {
            spawnerTime = 3.5f;
        }
        else if (GiftToHouse.score >= 11 && GiftToHouse.score <= 15)
        {
            spawnerTime = 3;
        }
        else if (GiftToHouse.score >= 16 && GiftToHouse.score <= 20)
        {
            spawnerTime = 2.5f;
        }
        else if (GiftToHouse.score >= 21 && GiftToHouse.score <= 25)
        {
            spawnerTime = 2;
        }
        
    }

    public void HouseSpawn()
    {
        if (PlayerMovement.canMove)
        {
            random = Random.Range(0, 2);
            sentHouse = houses[random];
            houses.RemoveAt(random);
            GetHouse();
        }
    }

    public void GetHouse()
    {
        sentHouse.SetActive(true);
        sentHouse.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
        
        houses.Add(sentHouse);
        sentHouse.transform.position = spawnerPos.position;
    }
}
