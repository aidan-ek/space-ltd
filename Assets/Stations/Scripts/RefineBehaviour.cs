using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineBehaviour : MonoBehaviour
{
    private GameObject scrap1;
    private GameObject scrap2;
    private GameObject result;

    private float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        scrap1 = GameObject.Find("StationManager").transform.GetChild(3).GetChild(0).gameObject;
        scrap2 = GameObject.Find("StationManager").transform.GetChild(3).GetChild(1).gameObject;
        result = GameObject.Find("StationManager").transform.GetChild(3).GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (scrap1.transform.childCount > 0 && scrap1.transform.GetChild(0).name == "Scrap(Clone)" && scrap2.transform.GetChild(0).name == "Scrap(Clone)" && Timer == 0)
        {
            UnityEngine.Debug.Log(scrap1.transform.GetChild(0).name);
            Timer = 5;
            Destroy(scrap1.transform.GetChild(0).gameObject);
            Destroy(scrap2.transform.GetChild(0).gameObject);
        }

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                GameObject bar = Instantiate(ItemList.items[3]);
                bar.transform.SetParent(result.transform);
                bar.transform.position = result.transform.position;
                bar.SetActive(true);

            }
        }
    }
}
