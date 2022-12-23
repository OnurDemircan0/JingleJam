using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    GameObject instantiatedBirds;
    public GameObject[] birds;
    public Transform[] spawnPoints;
    int randomBirds, randomPoint;
    public float birdSpawnTimes;
    float spawnTimes;
    void Start()
    {
        spawnTimes = birdSpawnTimes;
    }
    private void Update()
    {
        if (spawnTimes <= 0)
        {
            randomBirds = Random.Range(0, birds.Length);
            randomPoint = Random.Range(0, spawnPoints.Length);
            instantiatedBirds = Instantiate(birds[randomBirds], spawnPoints[randomPoint].transform.position, Quaternion.identity);
            spawnTimes = birdSpawnTimes;
        }
        else
        {
            spawnTimes -= Time.deltaTime;
        }
        Destroy(instantiatedBirds, 4f);
    }
}
