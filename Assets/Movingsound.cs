using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingsound : MonoBehaviour
{
    public SonarFxDescriptor sonarcontrol;
    public float sonarrate = 2f;

    private float nextsonar;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
           // print("The transform has changed!");

            if (Time.time > nextsonar)
            {
                nextsonar = Time.time + sonarrate;
                sonarcontrol.origin = transform.position;
                SonarFx.Instance.StartSonar(sonarcontrol);

            }

            transform.hasChanged = false;
        }


    }
}
