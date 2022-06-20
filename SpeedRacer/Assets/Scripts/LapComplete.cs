using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrigger;
    public GameObject HalfLapTrigger;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MillisDisplay;

    public LapTimeManager TimeManager;

    public GameObject car;

    public GameObject LapCounter;
    public int LapsDone;
    public int maxLaps;

    public GameObject MenuResultadosUI;
    public GameObject otroCoche;
    public GameObject ganador;
    public string nombre;

    private void OnTriggerEnter(Collider other)
    {
        // Aumentamos el numero de vueltas
        LapsDone += 1;

        // Actualizamos el marcador
        SecondDisplay.GetComponent<Text>().text = TimeManager.secondCount <= 9
           ? $"0{TimeManager.secondCount}:"
           : $"{TimeManager.secondCount}:";

        MinuteDisplay.GetComponent<Text>().text = TimeManager.minuteCount <= 9
           ? $"0{TimeManager.minuteCount}:"
           : $"{TimeManager.minuteCount}:";

        MillisDisplay.GetComponent<Text>().text = $"{(int)TimeManager.milliCount}";

        // Reseteamos cronometro
        TimeManager.minuteCount = 0;
        TimeManager.secondCount = 0;
        TimeManager.milliCount = 0;

        // Actualizamos cuenta vueltas
        LapCounter.GetComponent<Text>().text = "" + LapsDone;

        // Reseteamos triggers
        HalfLapTrigger.SetActive(true);
        LapCompleteTrigger.SetActive(false);

        // Si ha terminado la carrera...
        if (LapsDone == maxLaps)
        {
            // Deshabilitar controles ambos coches
            foreach (MonoBehaviour script in car.GetComponents<MonoBehaviour>())
            {
                script.enabled = false;
            }

            foreach (MonoBehaviour script in otroCoche.GetComponents<MonoBehaviour>())
            {
                script.enabled = false;
            }

            // Detener cronometro
            this.TimeManager.raceHasEnded();

            // Mostrar resultados
            ganador.GetComponent<UnityEngine.UI.Text>().text = "Ganador: " + nombre;
            MenuResultadosUI.SetActive(true);
        }
    }
}
