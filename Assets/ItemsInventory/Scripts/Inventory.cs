using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // inventory mechanics
    public static string[] inventory = new string[16];
    public static GameObject[] itemSlots = new GameObject[16];
    public GameObject itemSlot;
    public GameObject emptyItem;
    
    void Awake() 
    {
        // instantiates inventory grid as prefab
        GameObject grid = GameObject.Find("Grid");

        // generates 16 slots with 2 empty slots for structure
        emptyItem = GameObject.Find("EmptyItem");
        Instantiate(emptyItem, grid.transform);
        for (int i=0; i<4; i++) {
            itemSlots[i] = Instantiate(itemSlot, grid.transform);
        }
        Instantiate(emptyItem, grid.transform);
        for (int i=0; i<12; i++) {
            itemSlots[i] = Instantiate(itemSlot, grid.transform);
        }
    }
    void Start() {
        for (int i=0; i<16; i++) {
            if (itemSlots[i]) {Debug.Log(itemSlots[i].name);}
        }
    }

    void Update() {
        for (int i=0; i<16; i++) {
            if (itemSlots[i]) {
                if (itemSlots[i].transform.childCount > 0) {
                    inventory[i] = itemSlots[i].transform.GetChild(0).name;
                } else {
                    inventory[i] = null;
                }
            }
            
        }

        string output = "";
        foreach (string i in inventory) {
            output += "[" + i + "] ";
        }
        Debug.Log(output);
    }


    
}