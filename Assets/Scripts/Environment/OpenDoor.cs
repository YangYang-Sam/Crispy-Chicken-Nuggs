using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Transform doorPivot;
    [SerializeField] float openAngle;
    [SerializeField] float openTime;

    public bool doorOpened;
    public Doorswing doorswing;
    public Lightflickering lt;
    bool opening;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !opening)
        {
            doorswing.enabled = false;
            lt.enabled = false;
            Controldoor();
        }
    }

    public void Controldoor()
    {
        doorOpened = !doorOpened;
        StartCoroutine(OpenOrClose(doorOpened));
    }


    IEnumerator OpenOrClose(bool open)
    {
        var time = Time.time;
        var timePassed = 0f;

        opening = true;

        while (timePassed < openTime)
        {
            timePassed = Time.time - time;
            var angle = 0f;

            if (open)
            {
                angle = Mathf.Lerp(0, openAngle, timePassed / openTime);
            }
            else
            {
                angle = Mathf.Lerp(openAngle, 0, timePassed / openTime);
            }

            doorPivot.localRotation = Quaternion.Euler(0, angle, 0);
            yield return null;
        }

        opening = false;
    }
}
