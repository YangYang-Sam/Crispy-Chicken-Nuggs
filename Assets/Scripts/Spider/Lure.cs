using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour {

    public Patrol patrol;

    void OnCollisionEnter(Collision collision)
    {
        patrol.MoveToPosition(collision.contacts[0].point);


    }


	
}
