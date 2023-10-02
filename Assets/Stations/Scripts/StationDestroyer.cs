using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationDestroyer : MonoBehaviour
{

    // DESTROYS WHATEVER YOU SLOT INTO IT
    void Update()
    {
        if (gameObject.transform.childCount > 0) {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }
}
