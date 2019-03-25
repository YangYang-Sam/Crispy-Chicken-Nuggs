using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightflickering : MonoBehaviour
{
    public float maxlight= 1.0f;
    public float frequncy = 1.0f;
    public float startlight = 0f;
    new Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = Mathf.PingPong(Time.time* frequncy, maxlight)+startlight;
    }
}
