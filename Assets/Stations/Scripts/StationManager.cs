using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    private Dictionary<string, GameObject> stations = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //get each station and add it to stations
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            stations[gameObject.transform.GetChild(i).name] = gameObject.transform.GetChild(i).gameObject;
            //gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //set station with <name> to active
    public void ActivateStation(string name)
    {
        UnityEngine.Debug.Log("crazy");
        foreach(KeyValuePair<string, GameObject> entry in stations)
        {
            if (entry.Key == "CraftingTable")
            {
                continue;
            }
            //checks whether to activate or not
            if (entry.Key == name)
            {
                if (!stations[entry.Key].activeSelf)
                {
                    UnityEngine.Debug.Log(entry.Key);
                    stations[entry.Key].SetActive(true);
                    stations["CraftingTable"].SetActive(false);
                }
                else
                {
                    stations[entry.Key].SetActive(false);
                    stations["CraftingTable"].SetActive(true);
                }
                
            }
            else
            {
                stations[entry.Key].SetActive(false);
            }
        }
        
    }
}
