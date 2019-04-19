using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayDoor : MonoBehaviour
{
    public AudioSource doorOpen;
    public SonarFxDescriptor sonarcontrol;
    public Transform sonarPostion;
    public Player p;

    void Update()
    {
        
    }

    private void PlaySound()
    {
        doorOpen.Play();
        p.cannotpause = false;
        sonarcontrol.origin = sonarPostion.position;
        SonarFx.Instance.StartSonar(sonarcontrol);
    }
        

}
