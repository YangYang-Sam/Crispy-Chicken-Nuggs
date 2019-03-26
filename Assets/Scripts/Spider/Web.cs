using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    //private GameObject lure;
    private ChasingLure websound;
    public ChasingTarget target;

    private void Start()
    {
        websound=FindObjectOfType<ChasingLure>();
        //lure = GameObject.FindGameObjectWithTag("Lure");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            //isChasing.range = 100f;
            //lure.transform.position=transform.position;

            target.position = transform.position;
            websound.UpdateTarget(target);
        }
    }
}
