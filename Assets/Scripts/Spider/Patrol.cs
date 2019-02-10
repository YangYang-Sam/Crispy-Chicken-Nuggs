using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //define the public classes that will be used 
    public float speed;
    public float speedMultiplier;
    public float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    public Transform player;
    private int randomSpot;
    public bool isPatrolling;
    public bool isMovingToPosition;
    public bool isFollowing;
    private Animator animator;
    [SerializeField]
    private GameObject lure;

    // On start make sure the animator idle animation begins then aqquire random spot to move to but don't move until given command
    void Start()
    {
        animator = GetComponent<Animator>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // On update use both bools to define whether to follow the player or follow the patrol points
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isFollowing = true;
            isPatrolling = false;

        }

        if (isFollowing == true)
        {
            FollowPlayer();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isFollowing = false;
            isPatrolling = true;
        }

        if (isPatrolling == true)
        {
            EnemyPatrol();

        }

       

        if (isMovingToPosition == true)
        {
            MoveToPosition(lure.gameObject.transform.position);
        }
    


        animator.SetBool("isPatrolling", isPatrolling);
        animator.SetBool("isFollowing", isFollowing);
        animator.SetBool("isFollowing", isMovingToPosition);


    }
    // On enemy patrol, move to random spot  in relation to the determined speed, also rotate spider to look at predetermined move spot
    void EnemyPatrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        transform.LookAt(moveSpots[randomSpot]);
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
    // On follow player move toward player position and also look at player when doing so
    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position , speed * speedMultiplier * Time.deltaTime);
        transform.LookAt(player);
    }

    public void MoveToPosition(Vector3 target)
    {
        Debug.Log("Moving to position");
        isPatrolling = false;
        isFollowing = false;
        isMovingToPosition = true;

        if (isMovingToPosition == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * speedMultiplier * Time.deltaTime);
            transform.LookAt(target);
        }

        if (Vector3.Distance(transform.position, target) < 0.2f)
        {
            isMovingToPosition = false;
        }

    }
 
}
