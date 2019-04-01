using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorswing : MonoBehaviour
{
    public float angle=20f;
    public float swingfreq = 10f;
    public Transform pivot;

    public bool x;
    public bool y;
    public bool z;

    public float startposition = 0f;
    public bool clockwise;

    private float a;
    private float fx;
    private float fy;
    private float fz;
    private float multiplier;

    void Start()
    {
        pivot = GetComponent<Transform>();
        fx = x ? 1 : 0;
        fy = y ? 1 : 0;
        fz = z ? 1 : 0;
        multiplier = clockwise ? 1 : -1;
    }

    void Update()
    {
        //a = angle-Mathf.PingPong(Time.time*swingfreq, angle);
        a = multiplier * Mathf.PingPong(Time.time * swingfreq, angle)+startposition;

        pivot.localRotation = Quaternion.Euler(a*fx, a*fy, a*fz);
    }
}
