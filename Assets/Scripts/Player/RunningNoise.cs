using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningNoise : MonoBehaviour
{
    public ChasingTarget target;
    public SonarFxDescriptor sonarcontrol;
    public float sonarrate = 1f;
    public Light walklight;
    public AudioSource footStep;
    public AudioSource run;

    private float nextsonar;
    private Vector3 old;
    private Stamina s;
    private ChasingLure[] runningsound;
    private float passedtime=0f;

    void Start()
    {
        s=GetComponent<Stamina>();
        runningsound = FindObjectsOfType<ChasingLure>();
    }

    void Update()
    {
        if (s.isRunning)
        {
            //spider located
            target.position = transform.position;
            foreach (var r in runningsound)
            {
                r.UpdateTarget(target);
            }
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
                    run.pitch = Random.Range(0.75f, 1.25f);
                    run.Play();
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
                //light intensity 0-1 by time
                passedtime += Time.deltaTime;
                passedtime = Mathf.Clamp01(passedtime);
                walklight.intensity = Mathf.Lerp(0, 1, passedtime);
             

                if (Time.time > nextsonar)
                {
                    nextsonar = Time.time + sonarrate;
                    footStep.pitch = Random.Range(0.75f, 1.25f);
                    footStep.Play();
                    sonarcontrol.origin = transform.position;
                    SonarFx.Instance.StartSonar(sonarcontrol);
                }
                old = transform.position;
            }
            else
            {
                passedtime = 0;
                walklight.intensity = 0;
            }
        }
        
    }
}
