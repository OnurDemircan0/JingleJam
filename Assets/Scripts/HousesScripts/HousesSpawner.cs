using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> houses = new List<GameObject> ();
    GameObject sentHouse;
    int random;
    [SerializeField] Transform spawnerPos;

    private void Start() 
    {
        InvokeRepeating("HouseSpawn",1,2);
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            HouseSpawn();
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
