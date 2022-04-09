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

    private void OnTriggerEnter(Collider other)
    {
        SecondDisplay.GetComponent<Text>().text = LapTimeManager.secondCount <= 9
           ? $"0{LapTimeManager.secondCount}:"
           : $"{LapTimeManager.secondCount}:";

        MinuteDisplay.GetComponent<Text>().text = LapTimeManager.minuteCount <= 9
           ? $"0{LapTimeManager.minuteCount}:"
           : $"{LapTimeManager.minuteCount}:";

        MillisDisplay.GetComponent<Text>().text = $"{(int)LapTimeManager.milliCount}";

        LapTimeManager.minuteCount = 0;
        LapTimeManager.secondCount = 0;
        LapTimeManager.milliCount = 0;

        HalfLapTrigger.SetActive(true);
        LapCompleteTrigger.SetActive(false);
    }
}
