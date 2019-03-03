using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject Player;

    public float t = 0;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(t<0.04)
            t += 0.00001f;
        
        
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, 0);
        transform.localScale = new Vector3(transform.localScale.x, (transform.localScale.y + Time.deltaTime*3+t), transform.localScale.z);
    }
}
