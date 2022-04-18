using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class Countdown : MonoBehaviour
{
    public GameObject CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControls;

    void Start()
    {
        StartCoroutine(CountStart());    
    }

    IEnumerator CountStart()
    {
        // Esperar 0.5s antes de empezar cuenta atrás
        yield return new WaitForSeconds(0.5f);

        // Realizar cuenta atrás
        for (int i = 3; i > 0 ; i--)
        {
            CountDown.GetComponent<Text>().text = i.ToString();
            GetReady.Play();
            CountDown.SetActive(true);
            yield return new WaitForSeconds(1);
            CountDown.SetActive(false);
        }

        // Iniciar carrera
        GoAudio.Play();
        LapTimer.SetActive(true);

        // Habilitar los scripts de control
        var carScripts = CarControls.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in carScripts)
        {
            script.enabled = true;
        }
    }
}
