using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGate : MonoBehaviour
{
    public Transform pivot;
    public float closetime;
    public float closeangle;
    public float oldangle;
    public AudioSource closeGate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            closeGate.Play();
            StartCoroutine(Close());
            Destroy(gameObject,closetime);
        }
    }

    IEnumerator Close()
    {
        var time = Time.time;
        var timePassed = 0f;


        while (timePassed < closetime)
        {
            timePassed = Time.time - time;
            var angle = 0f;


            angle = Mathf.Lerp(oldangle, oldangle+closeangle, timePassed / closetime);

            pivot.localRotation= Quaternion.Euler(0, angle, 0);
            yield return null;
        }
    }
}
