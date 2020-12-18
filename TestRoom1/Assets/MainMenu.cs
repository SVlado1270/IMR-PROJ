using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadRoom1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadRoom2()
    {
        SceneManager.LoadScene("Room_2");
    }

    public void quitGame()
    {

        Application.Quit();
    }
}
