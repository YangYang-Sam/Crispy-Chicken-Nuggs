
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Door m_Door;
    private bool enterCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Door = GameObject.Find("Doorshaft").GetComponent<Door>();
    }


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
            if (Input.GetKeyDown(KeyCode.F))
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
