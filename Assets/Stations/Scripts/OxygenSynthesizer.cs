using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private const int regenSpeed = 3;
    private GameObject LivingMaterial;
    private StatController oxygenBar;

    private float Timer = 0;

    public GameObject stats;
    // Start is called before the first frame update
    void Start()
    {
        LivingMaterial = gameObject.transform.GetChild(0).gameObject;
        oxygenBar = stats.GetComponent<StatController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LivingMaterial.transform.childCount > 0 && LivingMaterial.transform.GetChild(0).name == "AstralAlgae(Clone)" && Timer == 0)
        {
            Timer = 60;
            oxygenBar.AddNetOxygen(regenSpeed);
            Destroy(LivingMaterial.transform.GetChild(0).gameObject);
        }

        if(Timer > 0)
        {
            Timer-=Time.deltaTime;
            if(Timer <= 0)
            {
                oxygenBar.AddNetOxygen(-regenSpeed);
            }
        }
        UnityEngine.Debug.Log(Timer);
    }
}
