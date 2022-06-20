using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool pausa = false;
    private float volumen = 0f;
    public GameObject MenuPausaUI;
    public GameObject MenuResultadosUI;

    void Start()
    {
        volumen = AudioListener.volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuResultadosUI.activeSelf)
            if (pausa)
                resume();
            else
                pause();
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pausa = false;
        AudioListener.volume = volumen;
        MenuPausaUI.SetActive(false);
    }

    public void pause()
    {
        Time.timeScale = 0f;
        pausa = true;
        AudioListener.volume = 0;
        MenuPausaUI.SetActive(true);
    }

    public void loadMainMenu()
    {
        resume();
        SceneManager.LoadScene("Menu");
    }
}
