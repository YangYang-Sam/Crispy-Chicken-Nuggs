using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotTrigger : MonoBehaviour
{
    public GameObject actor;
    public GameObject light;
    public GameObject anim;
    public AudioSource windowBreak;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            windowBreak.Play();
            anim.SetActive (true);
            light.SetActive(true);
            Destroy(actor, 12f);
        }
    }
}
