using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Health = 5;
    public int Score;
    public int Time;
    public int Breath = 5;
    public GameObject UI;
    public Canvas canvas;
    public Sprite Spr;
    public List<GameObject> Hearts;
    public int NumberOfHearts = 5;



    private int frame = 0;
    private bool TouchingWater = false;
    private int pastframe = 0;
    private RectTransform rect;
    private int DamageFromDrowning = 0;
    private int DamageNeeded = 0;






    // Start is called before the first frame update
    void Start()
    {



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
            rect.anchoredPosition = new Vector3(15 + ((i - 1) * 100), 0, 100);
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

                        Hearts[Hearts.Count - DamageNeeded].GetComponent<Image>().enabled = false;
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



    }
}
