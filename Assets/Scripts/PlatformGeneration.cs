using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject newPlatform;
    public GameObject Player;
    public GameObject Enemy;
    public Transform newPoint;
    public float SpaceBetweenY;
    public float SpaceBetweenX;
    public int VarianceX;
    public int VarianceY;

    private float platformWidth;
    private float platformHeight;
    private SpriteRenderer spr;
    private float DivergenceX;
    private float DivergenceY;
    private int spawnchance;
    

    // Start is called before the first frame update
    void Start()
    {
        
       
        spr = newPlatform.GetComponent<SpriteRenderer>();
        platformWidth = newPlatform.GetComponent<BoxCollider>().size.x;
        platformHeight = newPlatform.GetComponent<BoxCollider>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //randomness generation
        int randy = Random.Range(-2, 2);
        DivergenceX = Random.Range(-VarianceX, VarianceX);
        DivergenceY = Random.Range(-VarianceY, VarianceY);
        spawnchance = Random.Range(-3, 3);
        //
        //application of randomness
        if (randy > 0)
        {
            spr.flipX = true;
        }
        else
        {
            spr.flipX = false;
        }
        if (transform.position.y < newPoint.position.y)
        {
            if ((DivergenceX > platformWidth + SpaceBetweenX) || (transform.position.y - Player.transform.position.y > 5))
            {
                transform.position = new Vector3(transform.position.x+DivergenceX, transform.position.y + platformHeight + SpaceBetweenY, transform.position.z);
                Instantiate(newPlatform, transform.position, transform.rotation);
                if(spawnchance == 0)
                {
                    if (randy > 0)
                    {
                        Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y + platformHeight, transform.position.z), transform.rotation);
                    }
                    else
                    {
                        Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y + platformHeight, transform.position.z), Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z));
                    }
                }
            }
            if ((DivergenceX < -(platformWidth + SpaceBetweenX)) || (transform.position.y - Player.transform.position.y > 5))
            {
                transform.position = new Vector3(transform.position.x + DivergenceX, transform.position.y + platformHeight + SpaceBetweenY , transform.position.z);
                Instantiate(newPlatform, transform.position, transform.rotation);
                if (spawnchance == 0)
                {
                    if (randy > 0)
                    {
                        Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y + platformHeight, transform.position.z), transform.rotation);
                    }
                    else
                    {
                        Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y + platformHeight, transform.position.z), Quaternion.Euler(transform.rotation.x,180,transform.rotation.z));
                    }
                }
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
