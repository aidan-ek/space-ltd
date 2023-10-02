using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class StationSlotManager : MonoBehaviour
{
    public static int[] slots = new int[3];

    // checks for open spaces
    void Update()
    {
        for(int i=0; i<3; i++) {
            if (gameObject.transform.GetChild(i).childCount > 0) 
            {
                slots[i] = gameObject.transform.GetChild(i).childCount;
            }
        }
    }
}
