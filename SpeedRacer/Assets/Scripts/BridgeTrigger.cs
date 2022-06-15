using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    public GameObject BridgeTriggerObject;
    public GameObject RespawnObject;
    public List<GameObject> carsObjects;

    private void OnTriggerEnter(Collider collider)
    {
        carsObjects.ForEach(car =>
        {
            if (collider.gameObject == car)
            {
                float x = RespawnObject.transform.position.x;
                float y = RespawnObject.transform.position.y;
                float z = RespawnObject.transform.position.z;

                car.transform.position = new Vector3(x, y, z);
            }
        });

    }
}
