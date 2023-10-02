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
        int randResult = Random.Range(1, 100);
        int projID = 0;
        if (true) {
            projID = 0;
        }
        Transform clone = Instantiate(gameObject.transform.GetChild(projID), gameObject.transform);
        clone.gameObject.SetActive(true);
    }

}
