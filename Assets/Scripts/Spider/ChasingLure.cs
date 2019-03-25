﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct ChasingTarget
{
    [HideInInspector]public Vector3 position;
    public float range;
    public GameObject chasingTarget;
    public int level;
}

public class ChasingLure : MonoBehaviour
{
    public float delayAttack=2f;
    public float chasingSpeed=10f;

    public bool isChasing = false;

    public ChasingTarget target;
    private NavMeshAgent agent;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = delayAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            if (timer > 0)
            {
                timer-=Time.deltaTime;
            }
            Chasing();
        }
    }

    private void Chasing()
    {
        Vector3 moveposition = target.position;
        moveposition.y = transform.position.y;
        agent.destination = moveposition;
        //face to target
        transform.LookAt(moveposition);
        //delay of attack
        if (timer > 0)
        {
            return;
        }
        if (agent.path.corners.Length > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, agent.path.corners[1], chasingSpeed * Time.deltaTime);
        }
        else
        {
            Invoke("StopChasing", 2);
        }
    }

    private void StopChasing()
    {
        isChasing = false;
    }

    public void UpdateTarget(ChasingTarget newTarget)
    {
        float distance = Vector3.Distance(transform.position, newTarget.position);
        if (distance < newTarget.range)
        {
            if (!isChasing || target.level <= newTarget.level)
            {
                if (target.chasingTarget != newTarget.chasingTarget)
                {
                    timer = delayAttack;
                }
                target = newTarget;
                isChasing = true;
                CancelInvoke();
            }
        }
        else if (target.chasingTarget == newTarget.chasingTarget)
        {
            isChasing = false;
            timer = delayAttack;
        }
    }
}
