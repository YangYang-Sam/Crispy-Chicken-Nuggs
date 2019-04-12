using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearding : MonoBehaviour
{
    public GameObject wave;
    private ChasingLure[] luresound;
    public ChasingTarget target;

    float timer = 1;
   // private GameObject lure;

    void Start()
    {
        luresound = FindObjectsOfType<ChasingLure>();
        //lure = GameObject.FindGameObjectWithTag("Lure");
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (timer > 0)
        {
            return;
        }
        var p = Instantiate(wave, transform.position, transform.rotation);

        target.position = p.transform.position;
        foreach (var l in luresound)
        {
            l.UpdateTarget(target);
        }
        
        //isChasing.range = 5f;
        //lure.transform.position = p.transform.position;
        timer = 1;
        Destroy(p, 3);
    }


}
