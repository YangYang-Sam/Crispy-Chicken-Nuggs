using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRange : MonoBehaviour
{
    public float startRange;
    public float fullRange;

    Lightflickering lf;
    GameObject player;
    
    void Start()
    {
        lf = GetComponent<Lightflickering>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        lf.multiplier = Mathf.Lerp(1,0,(distance-fullRange)/(startRange-fullRange));
    }
}
