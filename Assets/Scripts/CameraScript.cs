using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public float speed;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float interpolation = speed * Time.deltaTime;

        Vector3 position = transform.position;
        position.y = Mathf.Lerp(transform.position.y, Player.transform.position.y, interpolation);
        position.x = Mathf.Lerp(transform.position.x, Player.transform.position.x, interpolation);

        transform.position = position;


    }
}
