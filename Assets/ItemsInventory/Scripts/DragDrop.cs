using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class DragDrop : MonoBehaviour
{
    // currently dragged object
    public GameObject selectedObject;
    private Vector3 originalPos;
    Vector3 offset; // amount to offset by when dragging

    void Update()
    {
        // gets mouse position in terms of world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // when mouse down, finds object overlapping with mouse and sets it to the selected object
        if (Input.GetMouseButtonDown(0) && Physics2D.OverlapPoint(mousePosition))
        {
            Collider2D[] results = Physics2D.OverlapPointAll(mousePosition);
            selectedObject = GetObjectFromTag(results, "Draggable");
            offset = selectedObject.transform.position - mousePosition;

            if (selectedObject) { originalPos = selectedObject.transform.position; } // saves original position of object
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        // when letting go of mouse, sets selected object to null
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            // Detects if dropping into an itemslot
            Collider2D[] dropResults = Physics2D.OverlapPointAll(mousePosition);
            GameObject objectDroppedOn = GetObjectFromTag(dropResults, "ItemSlot");
            if (objectDroppedOn) {
                selectedObject.transform.position = objectDroppedOn.transform.position; // snaps item to centre of slot if valid
            } else {
                selectedObject.transform.position = originalPos; //snaps back to original pos if no valid spot
            }
            

            selectedObject = null;
        }
    }

    // Takes collider2d list as input and returns the one with a specific tag
    GameObject GetObjectFromTag(Collider2D[] results, String tag)
    {
        foreach(Collider2D col in results)
        {
            GameObject g = col.transform.gameObject;
            if (g.tag == tag) {
                return g;
            }
        }
        return null;
    }
}
