using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    //private GameObject lure;
    private ChasingLure[] websound;
    public ChasingTarget target;
    public AudioSource snapTwig;

    private void Start()
    {
        websound=FindObjectsOfType<ChasingLure>();
        
        //lure = GameObject.FindGameObjectWithTag("Lure");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            snapTwig.Play();
            //isChasing.range = 100f;
            //lure.transform.position=transform.position;

            target.position = transform.position;
            foreach (var w in websound)
            {
                w.UpdateTarget(target);
            }
        }
    }
}
