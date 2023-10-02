using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    private double spawnTime;

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if(spawnTime > 1)
        {
            Instantiate(projectile, gameObject.transform);
            spawnTime -= 1;
        }
    }
}
