using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    //private GameObject lure;
    private ChasingLure[] websound;
    public ChasingTarget target;
    public AudioSource snapTwig;
    public PlayerMove pm;
    public float speeddivide=2f;

    private void Start()
    {
        websound=FindObjectsOfType<ChasingLure>();
        pm = FindObjectOfType<PlayerMove>();
        //lure = GameObject.FindGameObjectWithTag("Lure");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            snapTwig.Play();
            //isChasing.range = 100f;
            //lure.transform.position=transform.position;
            pm.speed = pm.speed / speeddivide;

            target.position = other.transform.position;
            foreach (var w in websound)
            {
                w.UpdateTarget(target);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pm.speed = pm.startspeed;
    }
}
