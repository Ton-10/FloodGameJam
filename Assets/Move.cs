/*
 Taveon Morrison  
 Feb 2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    //Initial Variables
    public float Speed = 5f;
    public float JumpPow = 10f;
    public float AirDrag = 1f;
    public float Grav = 1f;
    public Rigidbody RB;
    public GameObject camera;
    
    bool Debounce = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        

    }
    // on collide events
    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        //
        if (normal == (transform.up))
        {
            Debounce = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
      
        
        //Definining vertical and horizontal axis

        float FB = Input.GetAxis("Vertical");
        float RL = Input.GetAxisRaw("Horizontal");

       

        //right and left movement
        if ((RL > 0))
        {
            if (Debounce == true)
            {
                RB.velocity = new Vector3(Speed / AirDrag, RB.velocity.y);
            }
            else
            {
                RB.velocity = new Vector3(Speed, RB.velocity.y);
            }
        }
        else if ((RL < 0))
        {

            if (Debounce == true)
            {
                RB.velocity = new Vector3(-Speed / AirDrag, RB.velocity.y);
            }
            else
            {
                RB.velocity = new Vector3(-Speed, RB.velocity.y);
            }


        }
        else if (RL == 0)
        {
            RB.velocity = new Vector3(0,RB.velocity.y);
        }

        //Jump Code
        if (Input.GetButton("Jump") && Debounce == false)
        {
            
            Debounce = true;
            RB.velocity = (transform.up * JumpPow);
            
            
        }
        if (Debounce == true)
        {
            Vector3 vel = RB.velocity;
            vel.y -= Grav * Time.deltaTime;
            RB.velocity = vel;
        }


    }
}
