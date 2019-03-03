using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject newPlatform;
    public GameObject Player;
    public Transform newPoint;
    public float SpaceBetweenY;
    public float SpaceBetweenX;
    public int VarianceX;
    public int VarianceY;

    private float platformWidth;
    private float platformHeight;
    private float DivergenceX;
    private float DivergenceY;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = newPlatform.GetComponent<BoxCollider>().size.x;
        platformHeight = newPlatform.GetComponent<BoxCollider>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        DivergenceX = Random.Range(-VarianceX, VarianceX);
        DivergenceY = Random.Range(-VarianceY, VarianceY);

        if (transform.position.y < newPoint.position.y)
        {
            if ((DivergenceX > platformWidth + SpaceBetweenX) || (transform.position.y - Player.transform.position.y > 5))
            {
                transform.position = new Vector3(transform.position.x+DivergenceX, transform.position.y + platformHeight , transform.position.z);
                Instantiate(newPlatform, transform.position, transform.rotation);
            }
            if ((DivergenceX < -(platformWidth + SpaceBetweenX)) || (transform.position.y - Player.transform.position.y > 5))
            {
                transform.position = new Vector3(transform.position.x + DivergenceX, transform.position.y + platformHeight , transform.position.z);
                Instantiate(newPlatform, transform.position, transform.rotation);
            }
            
        }
        /*if (transform.position.x > newPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + SpaceBetweenX, DivergenceY , transform.position.z);
            Instantiate(newPlatform, transform.position, transform.rotation);


        }
        */
        
    }
}
