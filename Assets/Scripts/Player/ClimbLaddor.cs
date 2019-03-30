using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLaddor : MonoBehaviour
{
    private CharacterController p;
    Transform ChController;
    public bool isClimbingUp = false;
    public bool isClimbingDown = false;
    public float climbSpeed = 5f;

    private PlayerMove pm;
    private float xInput;
    private float yInput;

    void Start()
    {
        pm = GetComponent<PlayerMove>();
        p = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (isClimbingUp)
        {
            xInput = Input.GetAxis("Horizontal") *climbSpeed;
            yInput = Input.GetAxis("Vertical") * climbSpeed;

            Vector3 move = new Vector3(xInput, yInput,0);
            move = Vector3.ClampMagnitude(move, climbSpeed);
            move = transform.TransformVector(move);

            p.Move(move * Time.deltaTime);
        }

        if (isClimbingDown)
        {
            xInput = Input.GetAxis("Horizontal") * climbSpeed;
            yInput = Input.GetAxis("Vertical") * climbSpeed;

            Vector3 move = new Vector3(yInput, xInput, 0);
            move = Vector3.ClampMagnitude(move, climbSpeed);
            move = transform.TransformVector(move);

            p.Move(move * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laddor"&&isClimbingDown==false&&isClimbingUp==false)
        {
            pm.enabled = false;
            isClimbingUp = true;
        }

        if (other.gameObject.tag == "LaddorTop" && isClimbingDown == false && isClimbingUp == false)
        {
            pm.enabled = false;
            isClimbingDown = true;
        }

        if (other.gameObject.tag == "LaddorTop" && isClimbingDown == true)
        {
            pm.enabled = true;
            isClimbingDown = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LaddorTop" && isClimbingUp ==true&&isClimbingDown==false)
        {
            pm.enabled = true;
            isClimbingUp = false;
        }
    }
}
