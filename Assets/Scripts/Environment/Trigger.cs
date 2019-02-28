
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]private Door m_Door;
    private bool enterCollide = false;


    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("enter");
        enterCollide = true;
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("exit");
        enterCollide = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (enterCollide)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (m_Door.GetIsOpen())
                {
                    m_Door.CloseDoorMethod();

                }
                else
                {
                    m_Door.OpenDoorMethod();
                }
            }
        }

    }
}
