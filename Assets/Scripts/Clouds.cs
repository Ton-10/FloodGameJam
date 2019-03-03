using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody RB;

    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        RB = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(9, 10, (RB.velocity.y > 0.01f));
    }
}
