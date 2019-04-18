using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnim : MonoBehaviour
{
    public Animator anim;
    public float timer=1;

    void Update()
    {
        timer -= Time.deltaTime;
    }

    void Active()
    {
        if (timer > 0)
        {
            return;
        }
        anim.enabled = true;
    }
}
