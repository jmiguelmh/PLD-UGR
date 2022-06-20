using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrigger;
    public GameObject HalfLapTrigger;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MillisDisplay;

    public GameObject LapTimeBox;

    public LapTimeManager TimeManager;

    public GameObject LapCounter;
    public int LapsDone;

    private void OnTriggerEnter(Collider other)
    {
        LapsDone += 1;

        SecondDisplay.GetComponent<Text>().text = TimeManager.secondCount <= 9
           ? $"0{TimeManager.secondCount}:"
           : $"{TimeManager.secondCount}:";

        MinuteDisplay.GetComponent<Text>().text = TimeManager.minuteCount <= 9
           ? $"0{TimeManager.minuteCount}:"
           : $"{TimeManager.minuteCount}:";

        MillisDisplay.GetComponent<Text>().text = $"{(int)TimeManager.milliCount}";

        TimeManager.minuteCount = 0;
        TimeManager.secondCount = 0;
        TimeManager.milliCount = 0;
        LapCounter.GetComponent<Text>().text = "" + LapsDone;

        HalfLapTrigger.SetActive(true);
        LapCompleteTrigger.SetActive(false);
    }
}
