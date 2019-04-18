using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseOnce : MonoBehaviour
{
    public SonarFxDescriptor sonarcontrol;

    void Start()
    {
        sonarcontrol.origin = transform.position;
        SonarFx.Instance.StartSonar(sonarcontrol);
    }

    void Update()
    {
        
    }
}
