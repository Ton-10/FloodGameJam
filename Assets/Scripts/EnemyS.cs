using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    public int AttackChance = 1;
    public Animator anim;
    public bool TouchingPlayer = false;
    public GameObject Player;
    public Rigidbody RB;

    private int randy;
    private int frame;
    private int pastframe = 0;
    private int pastframe2;
    private bool attacked = false;
    private bool wasAttacked = false;
    private Move movescript;
    private PlayerStats playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        movescript = Player.GetComponent<Move>();
        playerStats = Player.GetComponent<PlayerStats>();
        RB = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision sub)
    {
        
        if (sub.gameObject.tag == "Player")
        {

            if (movescript.Attacking == true)
            {

                pastframe2 = frame;
                anim.SetBool("IsAttacked", true);
                wasAttacked = true;

            }
            else if (attacked == true)
            {
                
                playerStats.Health -= 1;
                playerStats.takeDmg = true;
            }
            TouchingPlayer = true;
        }
    }
    void OnCollisionExit(Collision sub)
    {
            if (sub.gameObject.tag == "Player")
            {
                TouchingPlayer = false;
                anim.SetBool("IsAttacked", false);
            }

     }
        // Update is called once per frame
        void Update()
    {
        frame += 1;

        randy = Random.Range(-AttackChance, AttackChance);
        //attacking
        if(randy == 0)
        {
            pastframe = frame;
            anim.SetBool("Attacking", true);
            attacked = true;
            

        }

        if ((frame - pastframe >= 60)&& attacked == true)
        {
            attacked = false;
            anim.SetBool("Attacking", false);
        }
        if ((frame - pastframe >= 20) && attacked == true)
        {
            RB.velocity = new Vector3(-transform.right.x, transform.up.y, 0) * 2;
        }
            //
            //attacked by player
            if ((frame - pastframe2 >= 60) && wasAttacked == true)
        {
            Destroy(gameObject);
        }
       //

        }
    
}
