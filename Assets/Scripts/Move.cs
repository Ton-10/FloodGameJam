﻿/*
 Taveon Morrison  
 Feb 2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    //Initial Variables
    public float Speed = 8f;
    public float JumpPow = 10f;
    public float AirDrag = 1f;
    public float Grav = 60f;
    public Rigidbody RB;
    public Animator anim;
    public bool Attacking = false;
    
    
    private bool Debounce = false;
    private bool Debounce2 = false;
    private int frame;
    private int pastframe;
    private int pastframe2;
    private float distance;
    private BoxCollider hitbox;
    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pastframe = 0;
        

    }
    // on collide events
    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        //collide with bottom of object
        if (normal == (transform.up))
        {
            Debounce = false;
        }
        if (normal == (transform.right) || normal == -(transform.right))
        {
            RB.velocity = new Vector3(0, RB.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {

        frame += 1;
      
        
        //Definining vertical and horizontal axis

        float FB = Input.GetAxis("Vertical");
        float RL = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", RL);
       

        //right and left movement
        if ((RL > 0) && Attacking == false)
        {
            if (Debounce == true)
            {
                RB.velocity = new Vector3(Speed / AirDrag, RB.velocity.y);
                
            }
            else
            {
                RB.velocity = new Vector3(Speed, RB.velocity.y);
                anim.SetBool("FacingR", true);
                anim.SetInteger("move", 1);
            }
        }
        else if ((RL < 0) && Attacking == false)
        {

            if (Debounce == true)
            {
                RB.velocity = new Vector3(-Speed / AirDrag, RB.velocity.y);
            }
            else
            {
                RB.velocity = new Vector3(-Speed, RB.velocity.y);
                anim.SetBool("FacingR", false);
                anim.SetInteger("move", -1);
            }


        }
        else if (RL == 0)
        {
            RB.velocity = new Vector3(0,RB.velocity.y);
            anim.SetInteger("move", 0);
        }

        //Jump Code
        if (Input.GetButtonDown("Jump") && Debounce == false && Attacking == false)
        {
            pastframe = frame;
            Debounce = true;
            RB.velocity = (transform.up * JumpPow);
            anim.SetBool("Jump", true);


        }
        if (frame - pastframe > 20)
        {
            anim.SetBool("Jump", false);
            
        }
        //checking if character is close to ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit))
        {
            
            distance = hit.distance;
            if (distance <= 1.5)
            {
                anim.SetBool("IsCloseToGround", true);
            }
            else
            {
                anim.SetBool("IsCloseToGround", false);
            }
        }
        if (Input.GetButtonDown("Fire1") && Debounce2 == false)
        {
            pastframe2 = frame;
            Debounce2 = true;
            Attacking = true;
            anim.SetBool("Attacking", true);
            anim.SetBool("Attacked", true);
            hitbox = gameObject.AddComponent<BoxCollider>();
            hitbox.size = new Vector3(1.5f,1,2);
            hitbox.center = new Vector3(0,0,0);


        }
        if (frame - pastframe2 > 20)
        {
            Attacking = false;
            anim.SetBool("Attacking", false);
            Destroy(hitbox);
            Debounce2 = false;

        }
        if (frame - pastframe2 > 5)
        {
            anim.SetBool("Attacked", false);
        }

        Vector3 vel = RB.velocity;
        vel.y -= Grav * Time.deltaTime;
        RB.velocity = vel;
    }
}
