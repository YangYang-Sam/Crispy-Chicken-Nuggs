using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningNoise : MonoBehaviour
{
    public ChasingTarget target;
    public SonarFxDescriptor sonarcontrol;
    public float sonarrate = 1f;

    private float nextsonar;
    private Vector3 old;
    private Stamina s;
    private ChasingLure runningsound;

    void Start()
    {
        s=GetComponent<Stamina>();
        runningsound = FindObjectOfType<ChasingLure>();
    }

    void Update()
    {
        if (s.isRunning)
        {
            //spider located
            target.position = transform.position;
            runningsound.UpdateTarget(target);
            //running wave
            sonarrate = 0.5f;
            sonarcontrol.duration = 2f;
            sonarcontrol.waveAmplitude = 0.5f;
            sonarcontrol.waveExponent = 100f;
            sonarcontrol.waveSpeed = 20f;
            if (old != transform.position)
            {
                if (Time.time > nextsonar)
                {
                    nextsonar = Time.time + sonarrate;
                    sonarcontrol.origin = transform.position;
                    SonarFx.Instance.StartSonar(sonarcontrol);

                }
                old = transform.position;
            }
        }
        else
        {
            sonarrate = 1f;
            sonarcontrol.duration = 1.5f;
            sonarcontrol.waveAmplitude = 0.5f;
            sonarcontrol.waveExponent = 1000f;
            sonarcontrol.waveSpeed = 10f;
            if (old != transform.position)
            {
                if (Time.time > nextsonar)
                {
                    nextsonar = Time.time + sonarrate;
                    sonarcontrol.origin = transform.position;
                    SonarFx.Instance.StartSonar(sonarcontrol);

                }
                old = transform.position;
            }
        }
        
    }
}
