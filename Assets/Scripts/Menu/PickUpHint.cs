using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHint : MonoBehaviour
{
    public GameObject pickuphint;
    public GameObject throwhint;
    public bool hintOn=false;
    public float holdingtimer = 1f;
    public Pickup p;

    private float timesaver;
    void Start()
    {
        timesaver = holdingtimer;
        p.holdingRock += P_holdingRock;
        p.throwRock += P_throwRock;
    }

    private void P_throwRock()
    {
        throwhint.SetActive(false);
        pickuphint.SetActive(false);
    }

    private void P_holdingRock(bool holding)
    {
        pickuphint.SetActive(holding);
        hintOn = holding;
        if (!holding)
            holdingtimer = timesaver;
        if (throwhint.activeInHierarchy)
            throwhint.SetActive(holding);
    }

    void Update()
    {
        if (!hintOn) return;
        
        holdingtimer -= Time.deltaTime;
        if (holdingtimer < 0)
        {
            pickuphint.SetActive(false);
            throwhint.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickuphint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickuphint.SetActive(false);
            throwhint.SetActive(false);
        }
    }
}
