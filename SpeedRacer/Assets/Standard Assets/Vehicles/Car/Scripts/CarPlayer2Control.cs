using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarPlayer2Control : MonoBehaviour
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

            if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                h = 0.0f;
            else if(Input.GetKey(KeyCode.LeftArrow))
                h = -1.0f;
            else if(Input.GetKey(KeyCode.RightArrow))
                h = 1.0f;
            
            if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow))
                v = 0.0f;
            else if(Input.GetKey(KeyCode.DownArrow))
                v = -1.0f;
            else if(Input.GetKey(KeyCode.UpArrow))
                v = 1.0f;

            /*
            if(Input.GetKey(KeyCode.RightControl))
                handbrake = 1.0f;
            */
            
            m_Car.Move(h, v, v, handbrake);

        }
    }
}
