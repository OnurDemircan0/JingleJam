using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    GameObject instantiatedBirds;
    public GameObject[] birds;
    public GameObject[] angryBirds;
    public Transform[] spawnPoints;
    int randomBirds, randomPoint;
    public float birdSpawnTimes;
    public static float spawnTimes;

    public static bool stopSpawnBird = false;

    void Start()
    {
        spawnTimes = birdSpawnTimes;
    }
    private void Update()
    {
        if (PlayerMovement.canMove && !stopSpawnBird)
        {
            if (PlayerMovement.time > 2f && spawnTimes <= 0)
            {
                randomBirds = Random.Range(0, angryBirds.Length);
                randomPoint = Random.Range(0, spawnPoints.Length);
                instantiatedBirds = Instantiate(angryBirds[randomBirds], spawnPoints[randomPoint].transform.position, Quaternion.identity);
                spawnTimes = birdSpawnTimes;
            }
            else
            {
                if (spawnTimes <= 0)
                {
                    randomBirds = Random.Range(0, birds.Length);
                    randomPoint = Random.Range(0, spawnPoints.Length);
                    instantiatedBirds = Instantiate(birds[randomBirds], spawnPoints[randomPoint].transform.position, Quaternion.identity);
                    spawnTimes = birdSpawnTimes;

                }
            }
            spawnTimes -= Time.deltaTime;
            Destroy(instantiatedBirds, 4f);
        }
        
    }

    public static IEnumerator StartSpawnBird()
    {
        if (!stopSpawnBird)
        {
            stopSpawnBird = true;
            yield return new WaitForSeconds(1f);
            stopSpawnBird = false;
        }
    }

}
