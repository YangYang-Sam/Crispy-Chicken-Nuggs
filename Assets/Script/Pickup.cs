﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Vector3 objectPos;
    float distance;

    public GameObject item;
    public GameObject HoldPostion;
    public bool isHolding = false;
    public float pickRange = 1f;
    public float throwForce = 600;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, HoldPostion.transform.position);
        //check if is holding
        if (isHolding == true&&distance<pickRange)
        {
            
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(HoldPostion.transform);

            if (Input.GetMouseButtonDown(1))
            {
                //throw
                item.GetComponent<Rigidbody>().AddForce(HoldPostion.transform.forward*throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        if (distance < pickRange)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    void OnMouseUp()
    {
        isHolding = false;
    }
}