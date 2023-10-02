using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private const float SPAWN_DELAY = 2;

    private double spawnTime;

    public bool starsSpawning = false;

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        // spawns a projectile every 1 second
        spawnTime += Time.deltaTime;
        if(spawnTime > SPAWN_DELAY)
        {
            SpawnRandomProjectile();
            spawnTime -= SPAWN_DELAY;
        }
    }

    // WIP
    void SpawnRandomProjectile() {
        int randResult = Random.Range(1, 81);
        int projID = 0; // algae
        if (randResult > 20 && randResult <= 40) 
        {
            projID = 1; // wisp
        } 
        else if (randResult > 40 && randResult <= 70) 
        {
            projID = 2; // scrap
        }
        else if (randResult > 70 && randResult <= 80) 
        {
            projID = 3; // ancient astroid (seeds)
        }

        Transform clone = Instantiate(gameObject.transform.GetChild(projID), gameObject.transform);
        clone.gameObject.SetActive(true);
    }

}
