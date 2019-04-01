using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCode : MonoBehaviour
{
    public GameObject EKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EKey.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EKey.SetActive(false);
    }


}