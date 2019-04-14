using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolOrderly : MonoBehaviour
{
    public Transform[] moveSpots;
    public float speed;
    public float startWaitTime;

    private ChasingLure isChasing;
    private int orderSpot;
    private float waitTime;
    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        waitTime = startWaitTime;
        orderSpot = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = moveSpots[orderSpot].position;
        isChasing = GetComponent<ChasingLure>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (isChasing.isChasing == false)
        {
            agent.destination = moveSpots[orderSpot].position;
            EnemyPatrol();
        }
    }

    void EnemyPatrol()
    {
        if (agent.path.corners.Length > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, agent.path.corners[1], speed * Time.deltaTime);
            transform.LookAt(agent.path.corners[1]);
            anim.SetFloat("Move", 1);
        }
        //If cube comes into contact of a distance of 0.2 of the position wait
        if (Vector3.Distance(transform.position, moveSpots[orderSpot].position) < 1f)
        {   //if wait time is less or equal to 0 move to another spot
            if (waitTime <= 0)
            {
                //if (orderSpot < (moveSpots.Length-1))
                //{
                //    orderSpot++;
                //    waitTime = startWaitTime;
                //}
                //else
                //{
                //    orderSpot = 0;
                //    waitTime = startWaitTime;
                //}
                orderSpot = ++orderSpot % moveSpots.Length;
                agent.destination = moveSpots[orderSpot].position;
                waitTime = startWaitTime;
            }
            else // minus or equal to time counter begins again once succesful position is met
            {
                waitTime -= Time.deltaTime;
            }

        }

    }
}