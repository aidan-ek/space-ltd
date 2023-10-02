using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Switch : MonoBehaviour
{
    public GameObject StationManagement;
    public GameObject station;

    public Sprite on;
    public Sprite off;

    private SpriteRenderer sprite;
    private StationManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = StationManagement.GetComponent<StationManager>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //picks which sprite to show depending if the station is active or not
        if (station.activeSelf)
        {
            sprite.sprite = on;
        }
        else
        {
            sprite.sprite = off;
        }
    }
    
    //if clicked activate station
    public void OnMouseDown()
    {
        manager.ActivateStation(station.name);
    }
}
