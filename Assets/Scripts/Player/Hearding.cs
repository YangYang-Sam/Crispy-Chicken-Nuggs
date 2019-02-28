using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearding : MonoBehaviour
{
    public GameObject wave;
    float timer=1;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (timer > 0)
        {
            return;
        }
        var p = Instantiate(wave, transform.position, transform.rotation);
        timer = 1;
        Destroy(p, 3);
    }


}
