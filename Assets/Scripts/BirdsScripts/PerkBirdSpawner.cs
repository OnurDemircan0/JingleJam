using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkBirdSpawner : MonoBehaviour
{
    GameObject instantiatedPerkBird;
    public GameObject perkBird;
    public Transform[] spawnPoints;
    public float perkBirdSpawnTimes;
    float spawnTimes;
    int randomPoint;
    void Update()
    {
        if (PlayerMovement.canMove)
        {
            if (spawnTimes <= 0 && BirdSpawner.spawnTimes <= 0)
            {
                StartCoroutine(BirdSpawner.StartSpawnBird());
                randomPoint = Random.Range(0, spawnPoints.Length);
                instantiatedPerkBird = Instantiate(perkBird, spawnPoints[randomPoint].transform.position, Quaternion.identity);
                spawnTimes = perkBirdSpawnTimes;
            }
            else
            {
                spawnTimes -= Time.deltaTime;
            }
            Destroy(instantiatedPerkBird, 4f);
        }
        
    }
}
