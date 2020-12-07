using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
    public void chooseScene1()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public void chooseScene2()
    {
        SceneManager.LoadScene("SecondScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
 
};
