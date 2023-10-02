using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBehaviour : MonoBehaviour
{
    private const int regenSpeed = 3;
    private GameObject LivingMaterial;
    private StatController oxygenBar;

    private float Timer = 0;

    private GameObject stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Stats");
        oxygenBar = stats.GetComponent<StatController>();

        UnityEngine.Debug.Log(stats.name);
        LivingMaterial = GameObject.Find("StationManager").transform.GetChild(1).GetChild(0).gameObject;
        
        UnityEngine.Debug.Log(LivingMaterial.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (LivingMaterial.transform.childCount > 0 && LivingMaterial.transform.GetChild(0).name == "AstralAlgae(Clone)" && Timer == 0)
        {
            UnityEngine.Debug.Log(LivingMaterial.transform.GetChild(0).name);
            Timer = 60;
            oxygenBar.AddNetOxygen(regenSpeed);
            Destroy(LivingMaterial.transform.GetChild(0).gameObject);
        }

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                oxygenBar.AddNetOxygen(-regenSpeed);
            }
        }
    }
}
