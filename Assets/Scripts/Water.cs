using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, 0);
        transform.localScale = new Vector3(transform.localScale.x, (transform.localScale.y + Time.deltaTime*2), transform.localScale.z);
    }
}
