﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayDoor : MonoBehaviour
{
    public AudioSource doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound()
    {
        doorOpen.Play();
    }
        

}
