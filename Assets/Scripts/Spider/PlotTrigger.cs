using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotTrigger : MonoBehaviour
{
    public GameObject actor;
    public GameObject light;
    public GameObject anim;
    public AudioSource windowBreak;
    public Player p;
    public BoxCollider b;

    private bool soundplayed=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            b.enabled = false;
            if (soundplayed == false)
            {
                windowBreak.Play();
                soundplayed = true;
            }
            p.cannotpause = true;
            anim.SetActive (true);
            light.SetActive(true);
            Destroy(actor, 12f);
        }
    }
}
