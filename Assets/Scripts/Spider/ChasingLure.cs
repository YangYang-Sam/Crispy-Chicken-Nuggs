using System.Collections;
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

    public AudioSource spiderWalk;
    public AudioSource spiderEyes;
    public bool mute;

    public bool isChasing = false;

    public ChasingTarget target;
    private NavMeshAgent agent;
    private float timer;
    private Animator anim;
    private SkinnedMeshRenderer skinRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spiderWalk.Play();
        agent = GetComponent<NavMeshAgent>();
        timer = delayAttack;
        anim = GetComponentInChildren<Animator>();
        skinRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            spiderWalk.pitch = Random.Range(1.75f, 2.00f);
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
            anim.SetFloat("Move", 0);
            spiderEyes.Play();
            spiderWalk.volume = Random.Range(0.0f, 0.01f);
            skinRenderer.material.SetColor("_EmissionColor", Color.white * ((Mathf.Sin(Time.time*8) + 1)*0.5f));
            return;
        }
        if (agent.path.corners.Length > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, agent.path.corners[1], chasingSpeed * Time.deltaTime);
            anim.SetFloat("Move", 2);
            spiderWalk.volume = Random.Range(1.0f, 1.01f);
            skinRenderer.material.SetColor("_EmissionColor", Color.black);
        }
        else
        {
            spiderWalk.pitch = Random.Range(1.00f, 1.00f);
            anim.SetFloat("Move", 0);
            spiderWalk.volume = Random.Range(0.0f, 0.01f);
            Invoke("StopChasing", 2);
        }
    }

    private void StopChasing()
    {
        isChasing = false;
        spiderWalk.volume = Random.Range(1.0f, 1.01f);
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
