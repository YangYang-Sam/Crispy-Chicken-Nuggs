using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public Animator anim;
    public Player p;
    public PlayerMove pm;
    public MenuController d;
 
    void Start()
    {
        anim.enabled = false;
    }

    void Update()
    {
        
    }
    //player positive touch enenmy and dead
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemey"))
        {
            Debug.Log("aaaaaaaah");
            anim.enabled = true;
            anim.Play("death");
            //off player controller
            p.enabled = false;
            pm.enabled = false;
            //open death menu
            d.isDead = true;
        }
    }

    //player negitive touch enenmy and dead
    private void OnCollisionEnter(Collision hit)
    {
        //print(hit.gameObject.name);
        if (hit.gameObject.CompareTag("Enemey"))
        {
            Debug.Log("aaaaaaaah");
            anim.enabled = true;
            anim.Play("death");
            //off player controller
            p.enabled = false;
            pm.enabled = false;
            //open death menu
            d.isDead = true;
        }
    }
}
