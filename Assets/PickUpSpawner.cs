using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject pickup;
    public GameObject hazard;
    public float range;
    public float spawnInterval;
    float spawnTimer;
    // Use this for initialization
    void Start()
    {
        spawnTimer = 0;
        
    }

    void spawnPickup()
    {
        GameObject spawnedPickup = Instantiate(pickup);
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        spawnedPickup.transform.position = transform.position + new Vector3(randomX,0, randomZ);

    }
    void spawnHazard()
    {
        GameObject spawnedPickup = Instantiate(hazard);
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        spawnedPickup.transform.position = transform.position + new Vector3(randomX, 0, randomZ);

    }
    // Update is called once per frame
    void Update()
    {
        
        

        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnInterval)
        {
            if (Random.Range(0, 10) > 8)
            {
                spawnHazard();
            }
            else
            {
                spawnPickup();
            }

            spawnTimer = 0;
        }
    }
}
