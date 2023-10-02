using UnityEngine;

public class ItemList : MonoBehaviour
{
    /*
    ITEM IDS:
    0: Ancient Fruit
    1: Ancient Seed
    2: Astral Algae
    3: Cosmic Bar
    4: Living Star
    5: Plasma Wisp
    6: Raw Plasma
    7: Scrap
    8: Thruster
    9: Starfuel
    */

    // each item prefab is a child of this gameobject. these are stored in this array 
    public static GameObject[] items;
    void Awake() {
        int itemCount = gameObject.transform.childCount;
        items = new GameObject[itemCount];
        for(int i = 0; i < gameObject.transform.childCount; i++) 
        {
            items[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    void Start() {
        int c = 0;
        foreach (GameObject i in items) {
            Debug.Log(c + ": " + i.name);
            c++;
        }
    }
}
