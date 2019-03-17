using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorswing : MonoBehaviour
{
    public float angle=20f;
    public float swingfreq = 10f;
    public Transform pivot;

    private float a;

    void Start()
    {
        
    }

    void Update()
    {
        a = angle-Mathf.PingPong(Time.time*swingfreq, angle);
        pivot.localRotation = Quaternion.Euler(0, a, 0);
    }
}
