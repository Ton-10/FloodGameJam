using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremngr : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        text.text = "Score:" + Score.scoreP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
