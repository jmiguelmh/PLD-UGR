using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LapTimeManager : MonoBehaviour
{
    public int minuteCount;
    public int secondCount;
    public float milliCount;
    public string milliDisplay;

    public GameObject minuteBox;
    public GameObject secondBox;
    public GameObject millisBox;

    // Update is called once per frame
    void Update()
    {
        milliCount += Time.deltaTime * 10;
        milliDisplay = milliCount.ToString("F0");
        millisBox.GetComponent<Text>().text = "" + milliDisplay;

        if (milliCount >= 10)
        {
            milliCount = 0;
            secondCount++;
        }

        if (secondCount <= 9)
            secondBox.GetComponent<Text>().text = $"0{secondCount}:";
        else
            secondBox.GetComponent<Text>().text = $"{secondCount}:";

        if (secondCount >= 60)
        {
            secondCount = 0;
            minuteCount++;
        }

        if (minuteCount <= 9)
            minuteBox.GetComponent<Text>().text = $"0{minuteCount}:";
        else
            minuteBox.GetComponent<Text>().text = $"{minuteCount}:";
    }
}
