using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController p;
    private float pitch;
    //member input values

    private float xMouse;
    private float yMouse;
    private float nextsonar;
    public AudioSource sonarClap;

    //grivaty
    public float ySpeed;
    public float gravity=-15f;
    public float jump =10f;

    public SonarFxDescriptor sonarcontrol;
    public float sonarrate=2f;

    public MenuController pause;

    public Transform fpsCam;
    [Range(5,15)]
    public float mSpeed=15f;

    [Range(45, 85)]
    public float pitchRange=45f;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<CharacterController>();
    }


    void Update()
    {
        GetInput();
        Updatemovement();

    }

    void GetInput()
    {
        xMouse = Input.GetAxis("Mouse X") * mSpeed;
        yMouse = Input.GetAxis("Mouse Y") * mSpeed;

    }

    void Updatemovement()
    {
        //mouse control view

        xMouse *= Time.deltaTime * 20;
        yMouse *= Time.deltaTime * 20;
        transform.Rotate(0, xMouse, 0);
        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);
        Quaternion CamRotation = Quaternion.Euler(pitch, 0, 0);
        fpsCam.localRotation = CamRotation;

        //grivaty
        if (p.isGrounded)
        {
            //if (Input.GetButtonDown("Jump"))
            //{
            //    ySpeed = jump;
            //}
            //else
            {
                ySpeed = gravity * Time.deltaTime;
            }
        }
        else
        {
            ySpeed += gravity * Time.deltaTime;
        }

        //controlsonar

        if (Input.GetKeyDown(KeyCode.F)&&Time.time>nextsonar)
        {
            sonarClap.Play();
            sonarClap.pitch = Random.Range(0.75f, 1.25f);
            nextsonar = Time.time + sonarrate;
            sonarcontrol.origin = transform.position;
            SonarFx.Instance.StartSonar(sonarcontrol);
        }

        //Pause Game

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.PauseGame();
        }

    }
    
}
