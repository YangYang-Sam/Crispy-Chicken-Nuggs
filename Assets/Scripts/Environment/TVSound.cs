using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSound : MonoBehaviour
{
    public GameObject wave;
    float timer = 2;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        else
        {
            var p = Instantiate(wave, transform.position, transform.rotation);
            timer = 2;
            Destroy(p, 3);
        }
    }
    
}
