using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    CursorLockMode wantedMode;


    // Apply requested cursor state
    void Start()
    {
        Cursor.lockState = wantedMode = CursorLockMode.Locked;

    }

    void Update()
    {
     
    }

}
