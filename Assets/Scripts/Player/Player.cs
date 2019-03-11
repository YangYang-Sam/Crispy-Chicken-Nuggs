using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController p;
    private float pitch;
    //member input values
    private float xInput;
    private float zInput;
    private float xMouse;
    private float yMouse;
    private float nextsonar;
    public AudioSource sonarClap;
    public float speed;
    public float speedup;
    public float startspeed;
    //grivaty
    public float ySpeed;
    public float gravity;
    public float jump=15;
    


    public SonarFxDescriptor sonarcontrol;
    public float sonarrate=2f;

    public MenuController pause;

    public Transform fpsCam;
    [Range(5,15)]
    public float mSpeed=10f;

    [Range(45, 85)]
    public float pitchRange;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<CharacterController>();
        startspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Updatemovement();

    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal") * speed;
        zInput = Input.GetAxis("Vertical") * speed;
        xMouse = Input.GetAxis("Mouse X") * mSpeed;
        yMouse = Input.GetAxis("Mouse Y") * mSpeed;

    }

    void Updatemovement()
    {
        //make movement face to view
        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        //jump
        if (p.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jump;
            }
            else
            {
                ySpeed = gravity * Time.deltaTime;
            }
        }
        else
        {
            ySpeed += gravity * Time.deltaTime;
        }
        p.Move((move + new Vector3(0, ySpeed, 0)) * Time.deltaTime);

        //mouse control view

        xMouse *= Time.deltaTime * 20;
        yMouse *= Time.deltaTime * 20;
        transform.Rotate(0, xMouse, 0);
        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);
        Quaternion CamRotation = Quaternion.Euler(pitch, 0, 0);
        fpsCam.localRotation = CamRotation;

        //controlsonar

        if(Input.GetKeyDown(KeyCode.F)&&Time.time>nextsonar)
        {
            sonarClap.Play();
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
