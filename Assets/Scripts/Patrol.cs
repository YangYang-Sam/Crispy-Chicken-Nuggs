using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //define the public classes that will be used 
    public float speed;
    public float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    // On start select a random spot to move to
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }
    
    // Change position and move towards new spot on update
    void Update()
    {
        EnemyPatrol();  

    }

    void EnemyPatrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        //If cube comes into contact of a distance of 0.2 of the position wait
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {   //if wait time is less or equal to 0 move to another spot
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;

            }
            else // minus or equal to time counter begins again once succesful position is met
            {
                waitTime -= Time.deltaTime;
            }

        }
    }
}
