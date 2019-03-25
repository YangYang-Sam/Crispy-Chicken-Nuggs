using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningNoise : MonoBehaviour
{
    private Stamina s;
    private ChasingLure runningsound;
    public ChasingTarget target;

    void Start()
    {
        s=GetComponent<Stamina>();
        runningsound = FindObjectOfType<ChasingLure>();
    }

    void Update()
    {
        if (s.isRunning)
        {
            target.position = transform.position;
            runningsound.UpdateTarget(target);
        }
    }
}
