using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadDriftTrack()
    {
        SceneManager.LoadScene("Drift Track");
    }

    public void loadSprintTrack()
    {
        SceneManager.LoadScene("Sprint Track");
    }

    public void salir()
    {
        Application.Quit();
    }
}
