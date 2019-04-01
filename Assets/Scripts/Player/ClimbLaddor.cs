using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLaddor : MonoBehaviour
{
    private CharacterController p;
    public bool isClimbing = false;
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
        if (isClimbing)
        {
            xInput = Input.GetAxis("Horizontal") *climbSpeed;
            yInput = Input.GetAxis("Vertical") * climbSpeed;

            Vector3 move = new Vector3(0, yInput,0);
            move = Vector3.ClampMagnitude(move, climbSpeed);
            move = transform.TransformVector(move);

            p.Move(move * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laddor")
        {
            if (!isClimbing)
            {
                pm.enabled = false;
                isClimbing = true;
            }
            else
            {
                pm.enabled = true;
                isClimbing = false;
            }
        }

        if (other.gameObject.tag == "LaddorTop" && isClimbing)
        {
            pm.enabled = true;
            isClimbing = false;
        }

    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Laddor")
    //    {
    //        pm.enabled = true;
    //        isClimbing = false;
    //    }
    //}
}
