using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    private bool moving;

    public RectTransform inventory;
    int direction = 30;
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 point = inventory.position;
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(point, axis, Time.deltaTime * direction);
            if (gameObject.transform.rotation.z >= 0.6)
            {
                direction = -30;
            }else if (gameObject.transform.rotation.z <= -0.6)
            {
                direction = 30;
            }
        }
    }

    public void toggleMovement()
    {
        moving = !moving;
    }
}
