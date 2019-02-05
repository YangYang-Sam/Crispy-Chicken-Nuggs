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
        // Release cursor on escape keypress
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = wantedMode = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cursor.lockState = wantedMode = CursorLockMode.Locked;
        }

    }

}
