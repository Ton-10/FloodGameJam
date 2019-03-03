using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int MaxHealth = 5;
    public int Time;
    public int Breath = 5;
    public GameObject UI;
    public Canvas canvas;
    public Sprite Spr;
    public List<GameObject> Hearts;
    public int NumberOfHearts;
    public bool takeDmg = false;
    public int Health = 1;



    private int frame = 0;
    private bool TouchingWater = false;
    private int pastframe = 0;
    private RectTransform rect;
    private int DamageFromDrowning = 0;
    private int DamageNeeded = 0;






    // Start is called before the first frame update
    void Start()
    {

        Health = MaxHealth;
        NumberOfHearts = MaxHealth;

        for (int i = 1; i <= NumberOfHearts; i++)

        {

            GameObject NewObj = new GameObject();
            NewObj.name = "Heart" + i;
            NewObj.tag = "Hearts";
            Image NewImage = NewObj.AddComponent<Image>();
            NewImage.sprite = Spr;
            NewObj.GetComponent<RectTransform>().SetParent(UI.transform);
            rect = NewObj.GetComponent<RectTransform>();
            rect.localScale = new Vector3(0.5f, 0.5f, 1);
            
            rect.anchoredPosition = new Vector3(0 + ((i - 1) * Screen.width/20), Screen.height/8.5f, 100);
            NewObj.SetActive(true);
        }


    }
    void OnTriggerEnter(Collider subject)
    {
        if (subject.tag == "Water")
        {
            TouchingWater = true;
        }

    }
    void OnTriggerExit(Collider subject)
    {
        if (subject.tag == "Water")
        {
            TouchingWater = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        frame += 1;

        Score.scoreP = System.Convert.ToInt32(System.Math.Round((transform.position.y)));
        
        //heart list stuff
        foreach (Transform child in UI.transform)
        {
            if (child.tag == "Hearts")
            {
                Hearts.Add(child.gameObject);

            }
        }
        //

        //water collision stuff
        if (TouchingWater == true)
        {
            if (frame - pastframe > 90)
            {
                pastframe = frame;
                Breath -= 1;
                if (Breath <= 0)
                {
                    Health -= 1;
                    DamageNeeded += 1;
                    //heart sprite removal
                    if (DamageFromDrowning < DamageNeeded)
                    {

                        Destroy(Hearts[(Hearts.Count)-1]);
                    }
                    //
                }
            }

        }
        if (TouchingWater == false)
        {
            Breath = 5;
        }
        //
        if (takeDmg == true)
        {

            Destroy(Hearts[(Hearts.Count)-1]);
            takeDmg = false;
        }

        if(Health <= 0)
        {
            SceneManager.LoadScene(sceneName: "GameOver");
        }
        if(transform.position.y < -1)
        {
            Health = 0;
        }

    }
}
