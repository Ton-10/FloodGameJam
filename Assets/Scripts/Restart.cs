using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button start, quit;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        start.onClick.AddListener(TaskOnClick);
        quit.onClick.AddListener(TaskOnClickQ);

    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
    
        SceneManager.LoadScene(sceneName: "MainLevel");
    }
    void TaskOnClickQ()
    {
        //Output this to console when Button1 or Button3 is clicked

        Application.Quit();
    }
}
