using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteTrigger;
    public GameObject HalfLapTrigger;
    public GameObject Car;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Car)
        {
            LapCompleteTrigger.SetActive(true);
            HalfLapTrigger.SetActive(false);
        }

    }
}
