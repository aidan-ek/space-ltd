using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminaryBehaviour : MonoBehaviour
{
    private GameObject star;

    private float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        star = GameObject.Find("StationManager").transform.GetChild(4).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (star.transform.childCount > 0 && star.transform.GetChild(0).name == "LivingStar(Clone)" && Timer == 0)
        {
            UnityEngine.Debug.Log(star.transform.GetChild(0).name);
            Timer = 5;
            Destroy(star.transform.GetChild(0).gameObject);
        }

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                GameObject plasma = Instantiate(ItemList.items[6]);
                plasma.transform.SetParent(star.transform);
                plasma.transform.position = star.transform.position;
                plasma.SetActive(true);
            }
        }
    }
}
