using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubatorBehaviour : MonoBehaviour
{
    private const int regenSpeed = 1;
    private GameObject stations;
    private GameObject seed;
    private StatController oxygenBar;
    private GameObject stats;

    private float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Stats");
        oxygenBar = stats.GetComponent<StatController>();
        seed = GameObject.Find("StationManager").transform.GetChild(2).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (seed.transform.childCount > 0 && seed.transform.GetChild(0).name == "AncientSeed(Clone)" && Timer == 0)
        {
            UnityEngine.Debug.Log(seed.transform.GetChild(0).name);
            Timer = 5;
            oxygenBar.AddNetOxygen(regenSpeed);
            Destroy(seed.transform.GetChild(0).gameObject);
        }

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                oxygenBar.AddNetOxygen(-regenSpeed);
                GameObject fruit = Instantiate(ItemList.items[0]);
                fruit.transform.SetParent(seed.transform);
                fruit.transform.position = seed.transform.position;
                fruit.SetActive(true);
            }
        }
    }
}
