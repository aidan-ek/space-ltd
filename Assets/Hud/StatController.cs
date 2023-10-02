using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StatController : MonoBehaviour
{
    private const int OXYGEN_MAX = 120;
    private const int HUNGER_MAX = 180;
    
    private int oxygen = OXYGEN_MAX;
    private int hunger = HUNGER_MAX;
    public int netOxygen = -2;

    private GameObject oxygenBarFill;

    void Awake() {
        oxygenBarFill = GameObject.Find("OxygenBarFill");
    }

    // Update is called once per frame
    private float timer = 0;
    void Update()
    {
        Debug.Log(oxygen);
        Debug.Log(timer);
        // changes the rate we decrement the oxygen based on the netoxygen
        timer += Time.deltaTime;
        if (timer >= 1f / Math.Abs(netOxygen)) {
            timer -= 1f / Math.Abs(netOxygen);
            oxygen += netOxygen / Math.Abs(netOxygen);
        }

        // updates oxygen bar display
        oxygenBarFill.gameObject.transform.localScale = new Vector3(oxygen*3.57f/OXYGEN_MAX, 0.58f, 1); // changes the scale based on % full
        oxygenBarFill.gameObject.transform.position = new Vector3(-1.8f*(OXYGEN_MAX - oxygen)/OXYGEN_MAX, -4.17f, 0); // shifts the position by half the scale to match
    }

    public void AddNetOxygen(int net) {
        netOxygen += net;
    }
}
