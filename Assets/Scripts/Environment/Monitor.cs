using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public Lightflickering lf;
    public Light lt;
    public float timer=2f;
    public bool playplot=false;
    public TitleMenu fade;

    private float nextup;

    void Update()
    {
        if (playplot)
        {
            if (lf.frequncy <= 5f)
            {
                if (Time.time > nextup)
                {
                    lf.frequncy = lf.frequncy + 2;
                    nextup = Time.time + timer;
                }
                return;
            }
            else if (timer > 0)
            {
                lf.enabled = false;
                lt.intensity = 2f;
                timer -= Time.deltaTime*2;
                return;
            }
            else
            {
                fade.Fade();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playplot = true;
        }
    }
}
