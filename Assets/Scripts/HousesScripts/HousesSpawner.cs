using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> houses = new();
    GameObject sentHouse;
    float spawnerTime;
    float nextSpawnerTime;
    float spawnSpeed;
    int random;
    
    [SerializeField] Transform spawnerPos;

    private void Start() 
    {
        nextSpawnerTime = 4;
        spawnerTime = nextSpawnerTime;
        spawnSpeed = 5;
    }
    private void Update() 
    {
        
        if (GiftToHouse.score >= 0 && GiftToHouse.score <= 5)
        {
            nextSpawnerTime = 1.5f;
            spawnSpeed = 7f;
            SpawnSpeed();
        }
        else if (GiftToHouse.score >= 6 && GiftToHouse.score <= 10)
        {
            nextSpawnerTime = 3.5f;
            spawnSpeed = 5.5f;
            SpawnSpeed();
        }
        else if (GiftToHouse.score >= 11 && GiftToHouse.score <= 15)
        {
            nextSpawnerTime = 3;
            spawnSpeed = 6.5f;
            SpawnSpeed();
        }
        else if (GiftToHouse.score >= 16 && GiftToHouse.score <= 20)
        {
            nextSpawnerTime = 2.5f;
            spawnSpeed = 7f;
            SpawnSpeed();
        }
        else if (GiftToHouse.score >= 21 && GiftToHouse.score <= 26)
        {
            nextSpawnerTime = 2;
            spawnSpeed = 7.5f;
            SpawnSpeed();
        }
        else
        {
            nextSpawnerTime = 1.5f;
            spawnSpeed = 8f;
            SpawnSpeed();
        }

        if(spawnerTime <= 0)
        {
            spawnerTime = nextSpawnerTime;
            HouseSpawn();
        }
        else
        {
            spawnerTime -= Time.deltaTime;
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
        sentHouse.transform.position = spawnerPos.position;
        sentHouse.GetComponent<Rigidbody2D>().velocity = Vector2.left * spawnSpeed;
        
        houses.Add(sentHouse);
    }

    void SpawnSpeed()
    {
        foreach(GameObject house in houses)
        {
            house.GetComponent<Rigidbody2D>().velocity = Vector2.left * spawnSpeed;
        }
    }

}
