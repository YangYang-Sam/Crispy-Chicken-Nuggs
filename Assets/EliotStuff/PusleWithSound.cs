using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusleWithSound : MonoBehaviour
{
    public SonarFxDescriptor sonarcontrol;
    public float sonarrate = 2f;
    private float nextsonar;

    
    void Start()
    {
        
    }

   
    void Update()
    {



        if (Time.time > nextsonar)
        {
            nextsonar = Time.time + sonarrate;
            sonarcontrol.origin = transform.position;
            SonarFx.Instance.StartSonar(sonarcontrol);


        }


        





    }


}
