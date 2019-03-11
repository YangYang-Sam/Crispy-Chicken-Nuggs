using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPlot : MonoBehaviour
{
    public Player p;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.tag);
            p.enabled = false;
        } 
    }
}
