using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Launching : MonoBehaviour
{
    public Inventory inventory;

    private GameObject launcher;
    private Oscillation launch;
    private Vector3 direction;
    private Vector3 origin;
    private GameObject equipped;
    private bool ret;
    // Start is called before the first frame update
    void Start()
    {
        launcher = gameObject.transform.parent.gameObject;
        launch = (Oscillation) launcher.GetComponent(typeof(Oscillation));
        origin = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && direction == Vector3.zero)
        {
            Vector3 pointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            launch.toggleMovement();

            origin = gameObject.transform.position;
            direction = gameObject.transform.position - launcher.transform.position;
            direction.z = 0;
        }

        if(equipped)
        {
            equipped.transform.position = gameObject.transform.position - (direction/8);
        }
        gameObject.transform.position += direction * Time.deltaTime * 4;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            ChangeDirection();
        }
        if (collision.tag == "Meteoroid")
        {
            if (direction != Vector3.zero && !equipped && !ret)
            {
                equipped = collision.gameObject;
                ChangeDirection();
            }
        }
        if (collision.tag == "Launcher")
        {
            direction = Vector3.zero;
            ret = false;
            gameObject.transform.position = origin;
            launch.toggleMovement();

            // gets the first open slot. if none open, ignores
            Transform firstOpenSlot = inventory.FirstOpenSlot();
            if (firstOpenSlot && equipped) 
            {
                // instantiates the item in the open slot
                GameObject storedItem = Instantiate(equipped.transform.GetChild(0).gameObject, firstOpenSlot);
                storedItem.SetActive(true);
            }
            
            if (equipped) { Destroy(equipped); }
            
        }
    }

    public void ChangeDirection()
    {
        ret = true;
        direction = -direction;
    }

}
