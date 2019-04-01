using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelSound : MonoBehaviour
{
    public AudioSource ambulance;
    public AudioSource doorBang;
    public AudioSource tv;
    public AudioSource tap;
    public AudioSource clock;

    private void OnTriggerStay(Collider other)
    {
        ambulance.Stop();
        doorBang.Stop();
        tv.Stop();
        tap.Stop();
        clock.Stop();

    }
}