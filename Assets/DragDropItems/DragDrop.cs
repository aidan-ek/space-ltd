using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class DragDrop : MonoBehaviour
{
    // currently dragged object
    public GameObject selectedObject;
    Vector3 offset; // amount to offset by when dragging

    void Update()
    {
        // gets mouse position in terms of world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // when mouse down, finds object overlapping with mouse and sets it to the selected object
        if (Input.GetMouseButtonDown(0))
        {
            // if object with physics 2d is overlapping with mouse, set it as selected
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition; // offsets when dragging
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        // when letting go of mouse, sets selected object to null
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }
}
