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

    void Start()
    {
        
    }


    void Update()
    {
        if (hintOn)
        {
            if (holdingtimer < 0)
            {
                pickuphint.SetActive(false);
                throwhint.SetActive(true);
            }
            else
            {
                throwhint.SetActive(false);
            }

            if (p.isHolding)
            {
                holdingtimer -= Time.deltaTime;
                return;
            }
            else
            {
                holdingtimer = 1f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintOn = true;
            pickuphint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintOn = false;
            pickuphint.SetActive(false);
        }
    }
}
