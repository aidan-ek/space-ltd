using System;
using UnityEngine;


public class DragDrop : MonoBehaviour
{   
    // drag/drop mechanisms
    public GameObject emptyItem;
    public GameObject selectedObject;
    private Vector3 originalPos;
    private Vector3 offset; // amount to offset by when dragging

    void Update()
    {
        // gets mouse position in terms of world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // when mouse down, finds object overlapping with mouse and sets it to the selected object
        if (Input.GetMouseButtonDown(0) && Physics2D.OverlapPoint(mousePosition))
        {
            Collider2D[] results = Physics2D.OverlapPointAll(mousePosition);
            selectedObject = GetObjectFromTag(results, "Draggable");

            // saves original position of object
            if (selectedObject) 
            { 
                offset = selectedObject.transform.position - mousePosition; 
                originalPos = selectedObject.transform.position;
            } 
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset; //new Vector3(mousePosition.x, mousePosition.y, 1);
        }

        // when letting go of mouse, sets selected object to null
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            // Detects if dropping into an itemslot
            Collider2D[] dropResults = Physics2D.OverlapPointAll(mousePosition + offset);
            GameObject objectDroppedOn = GetObjectFromTag(dropResults, "ItemSlot");
            if (objectDroppedOn && objectDroppedOn.transform.childCount == 0) {
                // destroys old empty item
                //Destroy(objectDroppedOn.transform.GetChild(0).gameObject);

                // snaps item to centre of slot if valid
                selectedObject.transform.position = objectDroppedOn.transform.position; 
                
                // fills old slot with empty item child
                // GameObject newEmpty = Instantiate(emptyItem, selectedObject.transform.parent);
                // newEmpty.name = "EmptyItem";

               // sets new parent to the slot
                selectedObject.transform.SetParent(objectDroppedOn.transform); 

            } else {
                //snaps back to original pos if no valid spot
                selectedObject.transform.position = originalPos; 
            }
            

            selectedObject = null; // deselects the currently dragged object
        }
    }

    // Takes collider2d list as input and returns the one with a specific tag
    GameObject GetObjectFromTag(Collider2D[] results, string tag)
    {
        foreach(Collider2D col in results)
        {
            if (col.CompareTag(tag)) {
                return col.transform.gameObject;
            }
        }
        return null;
    }
}
