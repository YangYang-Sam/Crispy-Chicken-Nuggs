using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public Animator anim;
    public Player p;
    public MenuController d;
 
    void Start()
    {
        anim.enabled = false;
    }

    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //print(hit.gameObject.name);
        if (hit.gameObject.CompareTag("Enemey"))
        {
            Debug.Log("aaaaaaaah");
            anim.enabled = true;
            anim.Play("death");
            //off player controller
            p.enabled = false;
            //open death menu
            d.isDead = true;
        }
    }
}
