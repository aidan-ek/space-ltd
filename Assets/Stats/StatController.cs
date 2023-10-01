using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StatController : MonoBehaviour
{
    private const int OXYGEN_MAX = 120;
    private const int HUNGER_MAX = 180;
    
    public int oxygen = OXYGEN_MAX;
    public int hunger = HUNGER_MAX;
    public int netOxygen = -5;

    public GameObject oxygenBarFill;

    void Awake() {
        oxygenBarFill = GameObject.Find("OxygenBarFill");
    }

    // Update is called once per frame
    private float timer = 0;
    void Update()
    {
        // runs code inside the if statement once every second
        timer += Time.deltaTime;
        if (timer >= 1) {
            timer -= 1;
            oxygen += netOxygen;
        }

        // updates oxygen bar display
        oxygenBarFill.gameObject.transform.localScale = new Vector3(oxygen*3f/OXYGEN_MAX, 0.4f, 1);
    }
}
