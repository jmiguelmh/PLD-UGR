using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarPlayer1Control : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = 0.0f;
            float v = 0.0f;
            float handbrake = 0.0f;

            if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                h = 0.0f;
            else if(Input.GetKey(KeyCode.A))
                h = -1.0f;
            else if(Input.GetKey(KeyCode.D))
                h = 1.0f;
            
            if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
                v = 0.0f;
            else if(Input.GetKey(KeyCode.S))
                v = -1.0f;
            else if(Input.GetKey(KeyCode.W))
                v = 1.0f;

            /*
            if(Input.GetKey(KeyCode.Space))
                handbrake = 1.0f;
            */

            m_Car.Move(h, v, v, handbrake);

        }
    }
}
