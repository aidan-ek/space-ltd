using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StatController : MonoBehaviour
{
    private const int OXYGEN_MAX = 100;
    private const int HUNGER_MAX = 120;
    
    private int oxygen = OXYGEN_MAX;
    private int hunger = HUNGER_MAX;
    private int netOxygen = -2;

    private GameObject oxygenBarFill;
    private GameObject hungerBarFill;

    void Awake() {
        oxygenBarFill = GameObject.Find("OxygenBarFill");
        hungerBarFill = GameObject.Find("HungerBarFill");
    }

    // Update is called once per frame
    private float oxyTimer = 0;
    private float hungerTimer = 0;
    void Update()
    {
        // changes the rate we decrement the oxygen based on the netoxygen
        oxyTimer += Time.deltaTime;
        if (oxyTimer >= 1f / Math.Abs(netOxygen)) {
            oxyTimer -= 1f / Math.Abs(netOxygen);
            oxygen += netOxygen / Math.Abs(netOxygen);
        }

        // reduces hunger by 1 every second
        hungerTimer += Time.deltaTime;
        if (hungerTimer >= 1) {
            hungerTimer--;
            hunger--;
        }
        
        if (oxygen > OXYGEN_MAX) {
            oxygen = OXYGEN_MAX;
        }
        if (hunger > HUNGER_MAX) {
            hunger = HUNGER_MAX;
        }

        // updates oxygen bar display
        // changes the scale based on % full
        oxygenBarFill.gameObject.transform.localScale = new Vector3(oxygen*3.64f/OXYGEN_MAX, 0.58f, 1); 
        hungerBarFill.gameObject.transform.localScale = new Vector3(hunger*3.64f/HUNGER_MAX, 0.58f, 1);
        // shifts the position by half the scale to match
        oxygenBarFill.gameObject.transform.position = new Vector3(-1.8f*(OXYGEN_MAX - oxygen)/OXYGEN_MAX, -4.17f, 0); 
        hungerBarFill.gameObject.transform.position = new Vector3(-1.8f*(HUNGER_MAX - hunger)/HUNGER_MAX, -3.34f, 0);


        if (oxygen <= 0 || hunger <= 0) {
            // LOSE GAME
        }
        
    }

    public void AddNetOxygen(int net) {
        netOxygen += net;
    }
}
