using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController p;
    private Player g;

    //member input values
    private float xInput;
    private float zInput;


    public float speed=5f;
    public float speedup=2f;
    public float startspeed;


    void Start()
    {
        p = GetComponent<CharacterController>();
        g = GetComponent<Player>();
        startspeed = speed;
    }


    void Update()
    {
        GetInput();
        Updatemovement();

    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal") * speed;
        zInput = Input.GetAxis("Vertical") * speed;
    }

    void Updatemovement()
    {
        //make movement face to view
        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        p.Move((move + new Vector3(0, g.ySpeed, 0)) * Time.deltaTime);
    }

}
